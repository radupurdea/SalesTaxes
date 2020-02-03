using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    class Program
    {
        static void Main(string[] args)
        {
            Country canada = new Country()
            {
                Name = "Canada",
                Currency = new Currency()
                {
                    Name = "CAD",
                    Symbol = "$"
                },
                TaxBands = new List<TaxBand>()
                {
                    new TaxBand() { TaxType = TaxType.BasicSalesTax, Name = "Sales Tax", ItemType = ProductType.Book, Percentage = 0M },
                    new TaxBand() { TaxType = TaxType.BasicSalesTax, Name = "Sales Tax", ItemType = ProductType.Food, Percentage = 0M },
                    new TaxBand() { TaxType = TaxType.BasicSalesTax, Name = "Sales Tax", ItemType = ProductType.MedicalProduct, Percentage = 0M },
                    new TaxBand() { TaxType = TaxType.BasicSalesTax, Name = "Sales Tax", ItemType = ProductType.Default, Percentage = 10M },
                    new TaxBand() { TaxType = TaxType.ImportSalesTax, Name = "Import Sales Tax", ItemType = ProductType.Default, Percentage = 5M },
                }
            };

            var builder = new ContainerBuilder();

            builder.RegisterType<BasicTaxSpecification>()
              .As<ISpecification<Product>>();

            builder.RegisterType<ImportTaxSpecification>()
              .As<ISpecification<Product>>()
              .PreserveExistingDefaults();
            builder.RegisterType<TaxCalculationEngine>().AsSelf();
            builder.RegisterInstance(canada).As<Country>();

            var container = builder.Build();

            TaxCalculationEngine taxCalculationEngine = container.Resolve<TaxCalculationEngine>();

            List<OrderProduct> orderProducts = new List<OrderProduct>()
            {
                new OrderProduct()
                {
                    Product = new Product()
                    {
                        CountryOfDelivery = "Canada",
                        ProductType = ProductType.Book,
                        UnitPrice = 12.49M,
                        Name = "book"
                    },
                    Quantity = 1,
                },
                new OrderProduct()
                {
                    Product = new Product()
                    {
                        CountryOfDelivery = "Canada",
                        ProductType = ProductType.Default,
                        UnitPrice = 14.99M,
                        Name = "music CD"
                    },
                    Quantity = 1,
                },
                new OrderProduct()
                {
                    Product = new Product()
                    {
                        CountryOfDelivery = "Canada",
                        ProductType = ProductType.Food,
                        UnitPrice = 0.85M,
                        Name = "chocolate bar"
                    },
                    Quantity = 1,
                }
            };

            orderProducts.ForEach(orderProduct => orderProduct.ExtendedAmount = orderProduct.Quantity * orderProduct.Product.UnitPrice);

            orderProducts.ForEach(orderProduct => taxCalculationEngine.ApplyTax(orderProduct));

            orderProducts.ForEach(orderProduct => orderProduct.TotalAmount = orderProduct.ExtendedAmount + orderProduct.ApplicableTaxes.Sum(t => t.TaxAmount));

            //Display receipt
            orderProducts.ForEach(o => Console.WriteLine($"{o.Quantity}{(o.Product.CountryOfDelivery != canada.Name ? " imported" : "")} {o.Product.Name}: {o.TotalAmount}"));

            Console.WriteLine($"Sales Taxes: {orderProducts.Sum(x => x.ApplicableTaxes.Sum(y => y.TaxAmount))} Total: {orderProducts.Sum(x => x.TotalAmount)}");

            Console.ReadLine();
        }
    }
}
