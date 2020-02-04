using System.Collections.Generic;
using System.Linq;
using TEK.Infrastructure.Interfaces;
using TEK.Infrastructure.Interfaces.DataContract;

namespace TEK.Purchase.Manager
{
    public class CartService : ICartService
    {
        public List<OrderProduct> Cart { get; private set; }

        readonly ITaxCalculatorService _taxCalculatorService;
        readonly ICountryDefinitionService _countryDefinitionService;

        public CartService(ITaxCalculatorService taxCalculatorService, ICountryDefinitionService countryDefinitionService)
        {
            Cart = new List<OrderProduct>();
            _taxCalculatorService = taxCalculatorService;
            _countryDefinitionService = countryDefinitionService;
        }

        public void AddToCart(Product selectedProduct)
        {
            if (selectedProduct == null)
                return;

            if(Cart.Any(x => x.Product == selectedProduct))
            {
                Cart.First(x => x.Product == selectedProduct).Quantity++;
            }
            else
            {
                Cart.Add(new OrderProduct()
                {
                    Product = selectedProduct,
                    Quantity = 1
                });
            }
            
            Cart.ForEach(orderProduct => orderProduct.ExtendedAmount = orderProduct.Quantity * orderProduct.Product.UnitPrice);

            Cart.ForEach(orderProduct => orderProduct.TotalAmount = orderProduct.ExtendedAmount);
        }

        public Receipt PreviewCart()
        {
            Receipt receipt = new Receipt();
            AddLineItems(receipt);

            return receipt;
        }

        public Receipt Checkout()
        {
            Cart.ForEach(orderProduct => _taxCalculatorService.ApplyTax(orderProduct));

            Cart.ForEach(orderProduct => orderProduct.TotalAmount += orderProduct.ApplicableTaxes.Sum(t => t.TaxAmount));

            Receipt receipt = new Receipt()
            {
                Total = Cart.Sum(orderProduct => orderProduct.TotalAmount),
                TotalTax = Cart.Sum(orderProduct => orderProduct.ApplicableTaxes.Sum(t => t.TaxAmount)),
            };
            
            AddLineItems(receipt);
            AddTaxItems(receipt);

            return receipt;
        }

        public void ClearCart()
        {
            Cart.Clear();
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

        private void AddLineItems(Receipt receipt)
        {
            Country storeCountry = _countryDefinitionService.GetCountry();

            Cart.ForEach(orderProduct => receipt.LineItems.Add(new LineItem()
            {
                Quantity = orderProduct.Quantity,
                Name = $"{(orderProduct.Product.CountryOfDelivery != storeCountry.Name ? "imported " : string.Empty)}{orderProduct.Product.Name}",
                UnitPrice = orderProduct.Product.UnitPrice,
                Total = orderProduct.TotalAmount
            }));
        }
    }
}
