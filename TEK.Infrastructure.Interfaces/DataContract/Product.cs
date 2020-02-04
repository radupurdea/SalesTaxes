using TEK.Infrastructure.Interfaces.Enum;

namespace TEK.Infrastructure.Interfaces.DataContract
{
    public class Product
    {
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public decimal UnitPrice { get; set; }
        public string CountryOfDelivery { get; set; }
    }
}
