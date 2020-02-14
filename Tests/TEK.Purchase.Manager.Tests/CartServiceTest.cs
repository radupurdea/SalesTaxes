using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEK.Infrastructure.Interfaces.DataContract;
using TEK.Infrastructure.Interfaces.Enum;
using TEK.Infrastructure.Interfaces;
using Moq;
using System.Linq;
using System.Collections.Generic;

namespace TEK.Purchase.Manager.Tests
{
    [TestClass]
    public class CartServiceTest
    {
        protected ICartService _cartService;
        protected Mock<ITaxCalculatorService> _mockTaxCalculatorDataAccess;
        protected Mock<ICountryDefinitionDataAccess> _mockCountryDefinitionDataAccess;
        protected Mock<ICartItemDataAccess> _mockCartItemDataAccess;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockTaxCalculatorDataAccess = new Mock<ITaxCalculatorService>(MockBehavior.Strict);
            _mockCountryDefinitionDataAccess = new Mock<ICountryDefinitionDataAccess>(MockBehavior.Strict);
            _mockCartItemDataAccess = new Mock<ICartItemDataAccess>(MockBehavior.Strict);

            _cartService = new CartService(_mockTaxCalculatorDataAccess.Object, _mockCountryDefinitionDataAccess.Object, _mockCartItemDataAccess.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockCountryDefinitionDataAccess.VerifyAll();
            _mockTaxCalculatorDataAccess.VerifyAll();
            _mockCartItemDataAccess.VerifyAll();
        }

        [TestMethod]
        public void AddToCart_AddProduct_ShouldReturnOrderProduct()
        {
            Product expectedproduct = new Product();
            expectedproduct.Name = "lollipop";
            expectedproduct.ProductType = ProductType.Food;
            expectedproduct.UnitPrice = 3.75M;
            expectedproduct.CountryOfDelivery = "Canada";

            List<OrderProduct> expectedCart = null;

            _mockCartItemDataAccess.Setup(x => x.GetCart()).Returns(new List<OrderProduct>());
            _mockCartItemDataAccess.Setup(x => x.SaveCart(It.IsAny<List<OrderProduct>>())).Callback<List<OrderProduct>>(x => expectedCart = x);

            _cartService.AddToCart(expectedproduct);

            Assert.IsNotNull(expectedCart);
            Assert.AreEqual(4, expectedCart.Capacity);
            Assert.AreEqual(1, expectedCart.Count);
            Assert.IsInstanceOfType(expectedCart.First(), typeof(OrderProduct));

            Product actualProduct = expectedCart.First().Product;

            Assert.IsNotNull(actualProduct);
            Assert.AreEqual(expectedproduct.Name, actualProduct.Name);
            Assert.AreEqual(expectedproduct.ProductType, actualProduct.ProductType);
            Assert.AreEqual(expectedproduct.UnitPrice, actualProduct.UnitPrice);
            Assert.AreEqual(expectedproduct.CountryOfDelivery, actualProduct.CountryOfDelivery);
        }

        [TestMethod]
        public void AddToCart_NullProduct_ShouldNotAddToCart()
        {
            _cartService.AddToCart(null);

            _mockCartItemDataAccess.Verify(x => x.GetCart(), Times.Never());
            _mockCartItemDataAccess.Verify(x => x.SaveCart(It.IsAny<List<OrderProduct>>()), Times.Never);
        }

        [TestMethod]
        public void Checkout_SelectedProducts_BaseSalesTax_ShouldReturnReceipt()
        {
            Receipt expectedReceipt = new Receipt()
            {
                Total = 29.83M,
                TotalTax = 1.50M
            };

            Product book = new Product();
            book.Name = "book";
            book.ProductType = ProductType.Book;
            book.UnitPrice = 12.49M;
            book.CountryOfDelivery = "Canada";
            
            Product musicCD = new Product();
            musicCD.Name = "music CD";
            musicCD.ProductType = ProductType.Default;
            musicCD.UnitPrice = 14.99M;
            musicCD.CountryOfDelivery = "Canada";
            
            Product chocolateBar = new Product();
            chocolateBar.Name = "chocolate bar";
            chocolateBar.ProductType = ProductType.Food;
            chocolateBar.UnitPrice = 0.85M;
            chocolateBar.CountryOfDelivery = "Canada";
            
            _mockCartItemDataAccess.Setup(x => x.GetCart()).Returns(new List<OrderProduct>()
            {
                new OrderProduct() { Product = book, Quantity = 1, ExtendedAmount = 12.49M, TotalAmount = 12.49M },
                new OrderProduct() { Product = musicCD, Quantity = 1, ExtendedAmount = 14.99M, TotalAmount = 14.99M },
                new OrderProduct() { Product = chocolateBar, Quantity = 1, ExtendedAmount = 0.85M, TotalAmount = 0.85M },

            });
            _mockCartItemDataAccess.Setup(x => x.SaveCart(It.IsAny<List<OrderProduct>>()));
            
            _mockTaxCalculatorDataAccess.Setup(f => f.ApplyTax(It.Is<OrderProduct>(o => o.Product == book))).Callback<OrderProduct>(o => o.ApplicableTaxes.Add(new ProductTax() { TaxAmount = 0M }));
            _mockTaxCalculatorDataAccess.Setup(f => f.ApplyTax(It.Is<OrderProduct>(o => o.Product == musicCD))).Callback<OrderProduct>(o => o.ApplicableTaxes.Add(new ProductTax() { TaxAmount = 1.5M }));
            _mockTaxCalculatorDataAccess.Setup(f => f.ApplyTax(It.Is<OrderProduct>(o => o.Product == chocolateBar))).Callback<OrderProduct>(o => o.ApplicableTaxes.Add(new ProductTax() { TaxAmount = 0M }));
            _mockCountryDefinitionDataAccess.Setup(f => f.GetCountry()).Returns(new Country() { Name = "Canada" });

            Receipt actualReceipt = _cartService.Checkout();

            Assert.IsNotNull(actualReceipt);
            Assert.AreEqual(expectedReceipt.Total, actualReceipt.Total);
            Assert.AreEqual(expectedReceipt.TotalTax, actualReceipt.TotalTax);
            Assert.AreEqual(3, actualReceipt.LineItems.Count);
            Assert.AreEqual(1, actualReceipt.TaxItems.Count);
        }

        [TestMethod]
        public void ClearCart_SelectedProducts_ShouldEmptyList()
        {
            List<OrderProduct> expectedCart = null;
            
            _mockCartItemDataAccess.Setup(x => x.SaveCart(It.IsAny<List<OrderProduct>>())).Callback<List<OrderProduct>>(x => expectedCart = x);
            
            _cartService.ClearCart();

            Assert.AreEqual(0, expectedCart.Count);
        }

        [TestMethod]
        public void PreviewCart_SelectedProducts_ShouldReturnReceipt()
        {
            Receipt expectedReceipt = new Receipt()
            {
                Total = 0M,
                TotalTax = 0M,
                LineItems = new System.Collections.Generic.List<LineItem>()
                {
                    new LineItem()
                    {
                        Quantity = 1,
                        UnitPrice = 12.49M
                    }
                }
            };

            Product book = new Product();
            book.Name = "book";
            book.ProductType = ProductType.Book;
            book.UnitPrice = 12.49M;
            book.CountryOfDelivery = "Canada";

            _mockCartItemDataAccess.Setup(x => x.GetCart()).Returns(new List<OrderProduct>()
            {
                new OrderProduct() { Product = book, Quantity = 1, ExtendedAmount = 12.49M, TotalAmount = 12.49M }
            });

            _mockCountryDefinitionDataAccess.Setup(f => f.GetCountry()).Returns(new Country() { Name = "Canada" });

            Receipt actualReceipt = _cartService.PreviewCart();

            Assert.IsNotNull(actualReceipt);
            Assert.AreEqual(expectedReceipt.Total, actualReceipt.Total);
            Assert.AreEqual(expectedReceipt.TotalTax, actualReceipt.TotalTax);
            Assert.AreEqual(1, actualReceipt.LineItems.Count);
            Assert.AreEqual(expectedReceipt.LineItems[0].UnitPrice, actualReceipt.LineItems[0].UnitPrice);
        }
    }
}
