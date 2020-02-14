using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEK.Infrastructure.Interfaces.DataContract;
using TEK.Infrastructure.Interfaces;

namespace TEK.Order.DataAccess.Tests
{
    [TestClass]
    public class StoreDefinitionDataAccessTest
    {
        [TestMethod]
        public void GetStoreProducts_DefaultStore_ShouldReturnNineProducts()
        {
            IStoreDefinitionDataAccess storeDefinitionService = new StoreDefinitionDataAccess();

            List<Product> storeProducts = storeDefinitionService.GetStoreProducts();

            Assert.IsNotNull(storeProducts);
            Assert.AreEqual(16, storeProducts.Capacity);
            Assert.AreEqual(9, storeProducts.Count);
            Assert.IsNotNull(storeDefinitionService);
        }
    }
}
