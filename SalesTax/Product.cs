using System;
using System.Collections.Generic;

namespace SalesTax
{
    public class Product 
    {
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public decimal UnitPrice { get; set; }
        public string CountryOfDelivery { get; set; }
    }

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

    public class ProductTax
    {
        public TaxBand TaxBand { get; set; }
        public decimal TaxAmount { get; set; }
    }
}