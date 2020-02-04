using System.Linq;

namespace SalesTax
{
    public class BasicTaxSpecification : ISpecification<Product>, ITaxableType
    {
        readonly Country _country;

        public TaxType TaxType { get; }

        public BasicTaxSpecification(Country country)
        {
            _country = country;
            TaxType = TaxType.BasicSalesTax;
        }
        
        public bool IsSatisfied(Product item)
        {
            return _country.TaxBands.Any(x => x.TaxType == TaxType && x.ProductType == item.ProductType);
        }
    }
}
