using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class TaxCalculationEngine
    {
        readonly Country _country;
        readonly IEnumerable<ISpecification<Product>> _taxSpecifications;

        public TaxCalculationEngine(Country country, IEnumerable<ISpecification<Product>> taxSpecifications)
        {
            _country = country;
            _taxSpecifications = taxSpecifications;
        }

        public void ApplyTax(OrderProduct orderProduct)
        {
            foreach(var taxSpecification in _taxSpecifications)
            {
                if (taxSpecification.IsSatisfied(orderProduct.Product))
                    CalculateTax(orderProduct, taxSpecification as ITaxableType);
            }
        }

        private void CalculateTax(OrderProduct orderProduct, ITaxableType taxType)
        {
            List<TaxBand> bands = _country.TaxBands.Where(x => x.TaxType == taxType.TaxType && x.ItemType == orderProduct.Product.ProductType).ToList(); 

            foreach (TaxBand taxBand in bands)
            {
                orderProduct.ApplicableTaxes.Add(new ProductTax()
                {
                    TaxBand = taxBand,
                    TaxAmount = Math.Round(orderProduct.ExtendedAmount * taxBand.Percentage / 100, 2,MidpointRounding.AwayFromZero)
                });
            }
        }
    }
}
