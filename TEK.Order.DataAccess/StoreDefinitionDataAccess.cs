using System.Collections.Generic;
using TEK.Infrastructure.Interfaces;
using TEK.Infrastructure.Interfaces.DataContract;
using TEK.Infrastructure.Interfaces.Enum;

namespace TEK.Order.DataAccess
{
    public class StoreDefinitionDataAccess : IStoreDefinitionDataAccess
    {
        public List<Product> GetStoreProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    CountryOfDelivery = "Canada",
                    ProductType = ProductType.Book,
                    UnitPrice = 12.49M,
                    Name = "book"
                },
                new Product()
                {
                    CountryOfDelivery = "Canada",
                    ProductType = ProductType.Default,
                    UnitPrice = 14.99M,
                    Name = "music CD"
                },
                new Product()
                {
                    CountryOfDelivery = "Canada",
                    ProductType = ProductType.Food,
                    UnitPrice = 0.85M,
                    Name = "chocolate bar"
                },
                new Product()
                {
                    CountryOfDelivery = "USA",
                    ProductType = ProductType.Food,
                    UnitPrice = 10M,
                    Name = "box of chocolates"
                },
                new Product()
                {
                    CountryOfDelivery = "USA",
                    ProductType = ProductType.Food,
                    UnitPrice = 11.25M,
                    Name = "box of chocolates"
                },
                new Product()
                {
                    CountryOfDelivery = "USA",
                    ProductType = ProductType.Default,
                    UnitPrice = 47.5M,
                    Name = "bottle of perfume"
                },
                new Product()
                {
                    CountryOfDelivery = "USA",
                    ProductType = ProductType.Default,
                    UnitPrice = 27.99M,
                    Name = "bottle of perfume"
                },
                new Product()
                {
                    CountryOfDelivery = "Canada",
                    ProductType = ProductType.Default,
                    UnitPrice = 18.99M,
                    Name = "bottle of perfume"
                },
                new Product()
                {
                    CountryOfDelivery = "Canada",
                    ProductType = ProductType.MedicalProduct,
                    UnitPrice = 9.75M,
                    Name = "packet of headache pills"
                }
            };
        }
    }
}
