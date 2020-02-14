using System;
using System.Collections.Generic;
using System.Linq;
using TEK.Infrastructure.Interfaces;
using TEK.Infrastructure.Interfaces.DataContract;

namespace TEK.Purchase.Manager
{
    public class CartService : ICartService
    {
        readonly ITaxCalculatorService _taxCalculatorDataAccess;
        readonly ICountryDefinitionDataAccess _countryDefinitionDataAccess;
        readonly ICartItemDataAccess _cartItemDataAccess;

        public CartService(ITaxCalculatorService taxCalculatorDataAccess, ICountryDefinitionDataAccess countryDefinitionDataAccess, ICartItemDataAccess cartItemDataAccess)
        {
            _taxCalculatorDataAccess = taxCalculatorDataAccess;
            _countryDefinitionDataAccess = countryDefinitionDataAccess;
            _cartItemDataAccess = cartItemDataAccess;
        }

        public void AddToCart(Product selectedProduct)
        {
            if (selectedProduct == null)
                return;

            var cart = _cartItemDataAccess.GetCart();

            if(cart.Any(x => x.Product == selectedProduct))
            {
                cart.First(x => x.Product == selectedProduct).Quantity++;
            }
            else
            {
                cart.Add(new OrderProduct()
                {
                    Product = selectedProduct,
                    Quantity = 1
                });
            }

            cart.ForEach(orderProduct => orderProduct.ExtendedAmount = orderProduct.Quantity * orderProduct.Product.UnitPrice);

            cart.ForEach(orderProduct => orderProduct.TotalAmount = orderProduct.ExtendedAmount);

            _cartItemDataAccess.SaveCart(cart);
        }

        public Receipt PreviewCart()
        {
            Receipt receipt = new Receipt();
            var cart = _cartItemDataAccess.GetCart();

            AddLineItems(receipt, cart);

            return receipt;
        }

        public Receipt Checkout()
        {
            var cart = _cartItemDataAccess.GetCart();

            cart.ForEach(orderProduct => _taxCalculatorDataAccess.ApplyTax(orderProduct));

            cart.ForEach(orderProduct => orderProduct.TotalAmount += orderProduct.ApplicableTaxes.Sum(t => t.TaxAmount));

            _cartItemDataAccess.SaveCart(cart);

            Receipt receipt = new Receipt()
            {
                Total = cart.Sum(orderProduct => orderProduct.TotalAmount),
                TotalTax = cart.Sum(orderProduct => orderProduct.ApplicableTaxes.Sum(t => t.TaxAmount)),
            };
            
            AddLineItems(receipt, cart);
            AddTaxItems(receipt);
            
            return receipt;
        }

        public void ClearCart()
        {
            _cartItemDataAccess.SaveCart(new List<OrderProduct>());
        }

        private static void AddTaxItems(Receipt receipt)
        {
            receipt.TaxItems = new List<LineItem>()
            {
                new LineItem()
                {
                    Name = "Sales Taxes",
                    Total = receipt.TotalTax
                }
            };
        }

        private void AddLineItems(Receipt receipt, List<OrderProduct> cart)
        {
            Country storeCountry = _countryDefinitionDataAccess.GetCountry();

            cart.ForEach(orderProduct => receipt.LineItems.Add(new LineItem()
            {
                Quantity = orderProduct.Quantity,
                Name = $"{(orderProduct.Product.CountryOfDelivery != storeCountry.Name ? "imported " : string.Empty)}{orderProduct.Product.Name}",
                UnitPrice = orderProduct.Product.UnitPrice,
                Total = orderProduct.TotalAmount
            }));
        }
    }
}
