using System.Collections.Generic;
using TEK.Infrastructure.Interfaces.DataContract;

namespace TEK.Infrastructure.Interfaces
{
    public interface IStoreDefinitionDataAccess
    {
        List<Product> GetStoreProducts();
    }
}
