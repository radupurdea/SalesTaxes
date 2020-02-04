using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEK.Infrastructure.Interfaces;
using TEK.Infrastructure.Interfaces.DataContract;
using System.Collections.Generic;
using TEK.Infrastructure.Interfaces.Enum;

namespace TEK.Order.DataAccess.Tests
{
    [TestClass]
    public class CountryDefinitionServiceTest
    {
        [TestMethod]
        public void GetCountry_DefaultStore_ShouldReturnCanada()
        {
            Country expectedCountry = new Country()
            {
                Name = "Canada",
                Currency = new Currency()
                {
                    Name = "CAD",
                    Symbol = "$"
                },
                TaxBands = new List<TaxBand>()
                {
                    new TaxBand() { TaxType = TaxType.BasicSalesTax, Name = "Sales Tax", ProductType = ProductType.Book, Percentage = 0M },
                    new TaxBand() { TaxType = TaxType.BasicSalesTax, Name = "Sales Tax", ProductType = ProductType.Food, Percentage = 0M },
                    new TaxBand() { TaxType = TaxType.BasicSalesTax, Name = "Sales Tax", ProductType = ProductType.MedicalProduct, Percentage = 0M },
                    new TaxBand() { TaxType = TaxType.BasicSalesTax, Name = "Sales Tax", ProductType = ProductType.Default, Percentage = 10M },
                    new TaxBand() { TaxType = TaxType.ImportSalesTax, Name = "Import Sales Tax", ProductType = ProductType.Default, Percentage = 5M },
                }
            };

            ICountryDefinitionService countryDefinitionService = new CountryDefinitionService();

            Country actualCountry = countryDefinitionService.GetCountry();

            Assert.IsNotNull(actualCountry);
            Assert.AreEqual(expectedCountry.Name, actualCountry.Name);
            Assert.IsNotNull(actualCountry.Currency);
            Assert.AreEqual(expectedCountry.Currency.Symbol, actualCountry.Currency.Symbol);
            Assert.AreEqual(expectedCountry.Currency.Name, actualCountry.Currency.Name);
            Assert.IsNotNull(actualCountry.TaxBands);
            Assert.AreEqual(8, actualCountry.TaxBands.Capacity);
            Assert.AreEqual(5, actualCountry.TaxBands.Count);
            Assert.IsNotNull(countryDefinitionService);
        }
    }
}
