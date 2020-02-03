using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class ImportTaxSpecification : ISpecification<Product>
    {
        readonly Country _country;

        public ImportTaxSpecification(Country country)
        {
            _country = country;
        }

        public bool IsSatisfied(Product item)
        {
            return item.CountryOfDelivery != _country.Name;
        }
    }
}
