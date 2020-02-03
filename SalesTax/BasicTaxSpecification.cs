using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class BasicTaxSpecification : ISpecification<Product>
    {
        readonly Country _country;

        public BasicTaxSpecification(Country country)
        {
            _country = country;
        }

        public bool IsSatisfied(Product item)
        {
            return _country.TaxBands.Where(x => x.Type == TaxType.BasicSalesTax)
                           .Any(x => x.TaxItems.Any(y => y.Type == item.Type));
        }
    }
}
