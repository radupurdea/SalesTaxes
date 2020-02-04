using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEK.Infrastructure.Interfaces.DataContract;

namespace TEK.Infrastructure.Interfaces
{
    public interface ICountryDefinitionService
    {
        Country GetCountry();
    }
}
