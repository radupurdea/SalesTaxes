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
        public string Name { get; set; }
        public TaxType TaxType { get; set; }

        public ProductType ProductType { get; set; }
        public decimal Percentage { get; set; }
    }
    
    public enum TaxType
    {
        BasicSalesTax,
        ImportSalesTax,
        FederalSalesTax,
    }
    
    public enum ProductType
    {
        Default,
        Book,
        Food,
        MedicalProduct
    }
}
