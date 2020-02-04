namespace TEK.Infrastructure.Interfaces.DataContract
{
    public class LineItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
}
