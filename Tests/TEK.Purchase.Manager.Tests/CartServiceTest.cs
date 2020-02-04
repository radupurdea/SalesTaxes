using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEK.Infrastructure.Interfaces.DataContract;
using TEK.Infrastructure.Interfaces.Enum;
using TEK.Infrastructure.Interfaces;
using Moq;
using System.Linq;

namespace TEK.Purchase.Manager.Tests
{
    [TestClass]
    public class CartServiceTest
    {
        protected ICartService _cartService;
        protected Mock<ITaxCalculatorService> _mockTaxCalculatorService;
        protected Mock<ICountryDefinitionService> _mockCountryDefinitionService;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockTaxCalculatorService = new Mock<ITaxCalculatorService>(MockBehavior.Strict);
            _mockCountryDefinitionService = new Mock<ICountryDefinitionService>(MockBehavior.Strict);

            _cartService = new CartService(_mockTaxCalculatorService.Object, _mockCountryDefinitionService.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockCountryDefinitionService.VerifyAll();
            _mockTaxCalculatorService.VerifyAll();
            _cartService.ClearCart();
        }

        [TestMethod]
        public void AddToCart_AddProduct_ShouldReturnOrderProduct()
        {
            Product expectedproduct = new Product();
            expectedproduct.Name = "lollipop";
            expectedproduct.ProductType = ProductType.Food;
            expectedproduct.UnitPrice = 3.75M;
            expectedproduct.CountryOfDelivery = "Canada";

            _cartService.AddToCart(expectedproduct);
            
            Assert.IsNotNull(_cartService.Cart);
            Assert.AreEqual(4, _cartService.Cart.Capacity);
            Assert.AreEqual(1, _cartService.Cart.Count);
            Assert.IsInstanceOfType(_cartService.Cart.First(), typeof(OrderProduct));

            Product actualProduct = _cartService.Cart.First().Product;

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

            Assert.IsNotNull(_cartService.Cart);
            Assert.AreEqual(0, _cartService.Cart.Count);
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

            _cartService.AddToCart(book);

            Product musicCD = new Product();
            musicCD.Name = "music CD";
            musicCD.ProductType = ProductType.Default;
            musicCD.UnitPrice = 14.99M;
            musicCD.CountryOfDelivery = "Canada";

            _cartService.AddToCart(musicCD);

            Product chocolateBar = new Product();
            chocolateBar.Name = "chocolate bar";
            chocolateBar.ProductType = ProductType.Food;
            chocolateBar.UnitPrice = 0.85M;
            chocolateBar.CountryOfDelivery = "Canada";

            _cartService.AddToCart(chocolateBar);

            _mockTaxCalculatorService.Setup(f => f.ApplyTax(It.Is<OrderProduct>(o => o.Product == book))).Callback<OrderProduct>(o => o.ApplicableTaxes.Add(new ProductTax() { TaxAmount = 0M }));
            _mockTaxCalculatorService.Setup(f => f.ApplyTax(It.Is<OrderProduct>(o => o.Product == musicCD))).Callback<OrderProduct>(o => o.ApplicableTaxes.Add(new ProductTax() { TaxAmount = 1.5M }));
            _mockTaxCalculatorService.Setup(f => f.ApplyTax(It.Is<OrderProduct>(o => o.Product == chocolateBar))).Callback<OrderProduct>(o => o.ApplicableTaxes.Add(new ProductTax() { TaxAmount = 0M }));
            _mockCountryDefinitionService.Setup(f => f.GetCountry()).Returns(new Country() { Name = "Canada" });

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
            Assert.AreEqual(0, _cartService.Cart.Count);

            Product book = new Product();
            book.Name = "book";
            book.ProductType = ProductType.Book;
            book.UnitPrice = 12.49M;
            book.CountryOfDelivery = "Canada";

            _cartService.AddToCart(book);

            Assert.AreEqual(1, _cartService.Cart.Count);

            _cartService.ClearCart();

            Assert.AreEqual(0, _cartService.Cart.Count);
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

            _cartService.AddToCart(book);
            
            _mockCountryDefinitionService.Setup(f => f.GetCountry()).Returns(new Country() { Name = "Canada" });

            Receipt actualReceipt = _cartService.PreviewCart();

            Assert.IsNotNull(actualReceipt);
            Assert.AreEqual(expectedReceipt.Total, actualReceipt.Total);
            Assert.AreEqual(expectedReceipt.TotalTax, actualReceipt.TotalTax);
            Assert.AreEqual(1, actualReceipt.LineItems.Count);
            Assert.AreEqual(expectedReceipt.LineItems[0].UnitPrice, actualReceipt.LineItems[0].UnitPrice);
        }
    }
}
