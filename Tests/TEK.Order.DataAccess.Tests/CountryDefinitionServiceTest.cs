using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEK.Infrastructure.Interfaces;
using TEK.Infrastructure.Interfaces.DataContract;

namespace TEK.Order.DataAccess.Tests
{
    [TestClass]
    public class CountryDefinitionServiceTest
    {
        [TestMethod]
        public void GetCountry379()
        {
            Country country;
            ICountryDefinitionService s0 = new CountryDefinitionService();
            country = s0.GetCountry();
            Assert.IsNotNull((object)country);
            Assert.AreEqual<string>("Canada", country.Name);
            Assert.IsNotNull(country.Currency);
            Assert.AreEqual<string>("$", country.Currency.Symbol);
            Assert.AreEqual<string>("CAD", country.Currency.Name);
            Assert.IsNotNull(country.TaxBands);
            Assert.AreEqual<int>(8, country.TaxBands.Capacity);
            Assert.AreEqual<int>(5, country.TaxBands.Count);
            Assert.IsNotNull((object)s0);
        }
    }
}
