using TEK.Infrastructure.Interfaces;
using TEK.Infrastructure.Interfaces.DataContract;
using TEK.Infrastructure.Interfaces.Enum;

namespace TEK.TaxCalculation.Engine
{
    public class ImportTaxSpecification : ISpecification<Product>, ITaxableType
    {
        public TaxType TaxType { get; }

        readonly ICountryDefinitionDataAccess _countryDefinitionService;

        public ImportTaxSpecification(ICountryDefinitionDataAccess countryDefinitionService)
        {
            _countryDefinitionService = countryDefinitionService;
            TaxType = TaxType.ImportSalesTax;
        }

        public bool IsSatisfied(Product item)
        {
            return item.CountryOfDelivery != _countryDefinitionService.GetCountry().Name;
        }
    }
}
