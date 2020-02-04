//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace TEK.Purchase.Manager.Tests
//{
//    [TestClass]
//    public class CartServiceTest
//    {
//        [TestMethod]
//        public void AddToCart520()
//        {
//            CartService cartService;
//            cartService =
//              new CartService((ITaxCalculatorService)null, (ICountryDefinitionService)null);
//            Product s0 = new Product();
//            s0.Name = (string)null;
//            s0.ProductType = ProductType.Default;
//            s0.UnitPrice = default(decimal);
//            s0.CountryOfDelivery = (string)null;
//            this.AddToCart(cartService, s0);
//            Assert.IsNotNull((object)cartService);
//            Assert.IsNotNull(cartService.Cart);
//            Assert.AreEqual<int>(4, cartService.Cart.Capacity);
//            Assert.AreEqual<int>(1, cartService.Cart.Count);
//        }

//        [TestMethod]
//        [RaisedException(typeof(NullReferenceException))]
//        public void AddToCartThrowsNullReferenceException555()
//        {
//            CartService cartService;
//            cartService =
//              new CartService((ITaxCalculatorService)null, (ICountryDefinitionService)null);
//            this.AddToCart(cartService, (Product)null);
//        }

//        [TestMethod]
//        [RaisedException(typeof(NullReferenceException))]
//        public void CheckoutThrowsNullReferenceException189()
//        {
//            CartService cartService;
//            Receipt receipt;
//            cartService =
//              new CartService((ITaxCalculatorService)null, (ICountryDefinitionService)null);
//            receipt = this.Checkout(cartService);
//        }

//        [TestMethod]
//        public void ClearCart324()
//        {
//            CartService cartService;
//            cartService =
//              new CartService((ITaxCalculatorService)null, (ICountryDefinitionService)null);
//            this.ClearCart(cartService);
//            Assert.IsNotNull((object)cartService);
//            Assert.IsNotNull(cartService.Cart);
//            Assert.AreEqual<int>(0, cartService.Cart.Capacity);
//            Assert.AreEqual<int>(0, cartService.Cart.Count);
//        }

//        [TestMethod]
//        [RaisedException(typeof(NullReferenceException))]
//        public void PreviewCartThrowsNullReferenceException229()
//        {
//            CartService cartService;
//            Receipt receipt;
//            cartService =
//              new CartService((ITaxCalculatorService)null, (ICountryDefinitionService)null);
//            receipt = this.PreviewCart(cartService);
//        }
//    }
//}
