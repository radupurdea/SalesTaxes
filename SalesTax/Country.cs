using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class Country
    {
        public string Name { get; set; }

        public Currency Currency { get; set; }

        public List<TaxBand> TaxBands { get; set; }
    }

    public class Currency
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
    public class TaxBand
    {
        public TaxType Type { get; set; }
        public List<TaxItemPercentage> TaxItems { get; set; }
    }

    public class TaxItemPercentage
    {
        public ItemType Type { get; set; }
        public decimal Percentage { get; set; }
    }

    public enum TaxType
    {
        BasicSalesTax,
        ImportSalesTax,
        FederalSalesTax,
    }
    public enum ItemType
    {
        Book,
        Food,
        MedicalProduct,
        Other,
    }
}
