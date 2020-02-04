using TEK.Infrastructure.Interfaces.Enum;

namespace TEK.Infrastructure.Interfaces.DataContract
{
    public class TaxBand
    {
        public string Name { get; set; }
        public TaxType TaxType { get; set; }

        public ProductType ProductType { get; set; }
        public decimal Percentage { get; set; }
    }
}
