using System.Linq;
using TEK.Infrastructure.Interfaces;
using TEK.Infrastructure.Interfaces.DataContract;
using TEK.Infrastructure.Interfaces.Enum;

namespace TEK.Tax.Manager
{
    public class BasicTaxSpecification : ISpecification<Product>, ITaxableType
    {
        readonly ICountryDefinitionService _countryDefinitionService;

        public TaxType TaxType { get; }

        public BasicTaxSpecification(ICountryDefinitionService countryDefinitionService)
        {
            _countryDefinitionService = countryDefinitionService;
            TaxType = TaxType.BasicSalesTax;
        }

        public bool IsSatisfied(Product item)
        {
            Country storeCountry = _countryDefinitionService.GetCountry();

            return storeCountry.TaxBands
                               .Any(x => x.TaxType == TaxType && x.ProductType == item.ProductType);
        }
    }
}
