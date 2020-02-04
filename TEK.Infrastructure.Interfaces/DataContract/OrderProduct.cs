using System.Collections.Generic;

namespace TEK.Infrastructure.Interfaces.DataContract
{
    public class OrderProduct
    {
        public OrderProduct()
        {
            ApplicableTaxes = new List<ProductTax>();
        }
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public List<ProductTax> ApplicableTaxes { get; set; }

        public decimal ExtendedAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
