using System;

namespace SalesTax
{
    public class Product
    {
        public ItemType Type { get; set; }
        public decimal Price { get; set; }
        public string CountryOfDelivery { get; set; }
    }

    public class OrderProduct : ITaxable
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
        
        public decimal TaxPercentage { get; set; }

        public Tax CalculateTax()
        {
            return new Tax(Product.Price * TaxPercentage / 100);
        }
    }

    public interface ITaxable
    {
        decimal TaxPercentage { get; set; }
        Tax CalculateTax();
    }

    public class Tax
    {
        public Tax(decimal amount)
        {
            Amount = amount;
        }

        public string Name { get; }
        public TaxType Type { get; }
        public decimal Amount { get; } 
    }
}