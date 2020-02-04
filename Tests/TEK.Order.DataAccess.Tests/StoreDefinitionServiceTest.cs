using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEK.Infrastructure.Interfaces.DataContract;
using TEK.Infrastructure.Interfaces;

namespace TEK.Order.DataAccess.Tests
{
    [TestClass]
    public class StoreDefinitionServiceTest
    {
        [TestMethod]
        public void GetStoreProducts_DefaultStore_ShouldReturnNineProducts()
        {
            IStoreDefinitionService storeDefinitionService = new StoreDefinitionService();

            List<Product> storeProducts = storeDefinitionService.GetStoreProducts();

            Assert.IsNotNull(storeProducts);
            Assert.AreEqual(16, storeProducts.Capacity);
            Assert.AreEqual(9, storeProducts.Count);
            Assert.IsNotNull(storeDefinitionService);
        }
    }
}
