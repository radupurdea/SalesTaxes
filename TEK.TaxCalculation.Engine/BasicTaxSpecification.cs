using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEK.Infrastructure.Interfaces;
using TEK.Infrastructure.Interfaces.DataContract;
using TEK.Infrastructure.Interfaces.Enum;

namespace TEK.TaxCalculation.Engine
{
    public class BasicTaxSpecification : ISpecification<Product>, ITaxableType
    {
        readonly ICountryDefinitionDataAccess _countryDefinitionService;

        public TaxType TaxType { get; }

        public BasicTaxSpecification(ICountryDefinitionDataAccess countryDefinitionService)
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
