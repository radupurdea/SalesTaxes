using System.Collections.Generic;
using TEK.Infrastructure.Interfaces.DataContract;

namespace TEK.Infrastructure.Interfaces
{
    public interface IStoreDefinitionService
    {
        List<Product> GetStoreProducts();
    }
}
