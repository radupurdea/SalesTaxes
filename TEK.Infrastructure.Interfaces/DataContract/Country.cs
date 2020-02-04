using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEK.Infrastructure.Interfaces.DataContract
{
    public class Country
    {
        public string Name { get; set; }

        public Currency Currency { get; set; }

        public List<TaxBand> TaxBands { get; set; }
    }
}
