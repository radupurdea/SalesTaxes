using System.Collections.Generic;
using TEK.Infrastructure.Interfaces;
using TEK.Infrastructure.Interfaces.DataContract;
using TEK.Infrastructure.Interfaces.Enum;

namespace TEK.Order.DataAccess
{
    public class CountryDefinitionService : ICountryDefinitionService
    {
        public Country GetCountry()
        {
            Country canada = new Country()
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

            return canada;
        }
    }
}
