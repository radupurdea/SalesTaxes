using System.Collections.Generic;

namespace TEK.Infrastructure.Interfaces.DataContract
{
    public class Receipt
    {
        public Receipt()
        {
            LineItems = new List<LineItem>();
            TaxItems = new List<LineItem>();
        }

        public List<LineItem> LineItems { get; set; }
        public List<LineItem> TaxItems { get; set; }
        public decimal TotalTax { get; set; }
        public decimal Total { get; set; }
    }
}
