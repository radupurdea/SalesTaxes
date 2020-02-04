using System;
using System.Collections.Generic;
using System.Linq;
using TEK.Infrastructure.Interfaces;
using TEK.Infrastructure.Interfaces.DataContract;

namespace TEK.TaxCalculation.Engine
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        readonly ICountryDefinitionService _countryDefinitionService;
        readonly IEnumerable<ISpecification<Product>> _taxSpecifications;

        public TaxCalculatorService(ICountryDefinitionService countryDefinitionService, IEnumerable<ISpecification<Product>> taxSpecifications)
        {
            _countryDefinitionService = countryDefinitionService;
            _taxSpecifications = taxSpecifications;
        }

        public void ApplyTax(OrderProduct orderProduct)
        {
            foreach (var taxSpecification in _taxSpecifications)
            {
                if (taxSpecification.IsSatisfied(orderProduct.Product))
                    CalculateTax(orderProduct, taxSpecification as ITaxableType);
            }
        }

        private void CalculateTax(OrderProduct orderProduct, ITaxableType taxType)
        {
            Country storeCountry = _countryDefinitionService.GetCountry();

            List<TaxBand> bands = storeCountry.TaxBands
                                              .Where(x => x.TaxType == taxType.TaxType && x.ProductType == orderProduct.Product.ProductType)
                                              .ToList();
            if (!bands.Any())
                bands = storeCountry.TaxBands
                                    .Where(x => x.TaxType == taxType.TaxType && x.ProductType == Infrastructure.Interfaces.Enum.ProductType.Default)
                                    .ToList();

            foreach (TaxBand taxBand in bands)
            {
                orderProduct.ApplicableTaxes.Add(new ProductTax()
                {
                    TaxBand = taxBand,
                    TaxAmount = Math.Ceiling(orderProduct.ExtendedAmount * taxBand.Percentage / 100 * 20) / 20
                });
            }
        }
    }
}
