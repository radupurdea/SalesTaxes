
namespace SalesTax
{
    public class ImportTaxSpecification : ISpecification<Product>, ITaxableType
    {
        readonly Country _country;

        public TaxType TaxType { get; }

        public ImportTaxSpecification(Country country)
        {
            _country = country;
            TaxType = TaxType.ImportSalesTax;
        }

        public bool IsSatisfied(Product item)
        {
            return item.CountryOfDelivery != _country.Name;
        }
    }
}
