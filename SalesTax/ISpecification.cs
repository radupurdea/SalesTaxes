using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T item);
    }
}
