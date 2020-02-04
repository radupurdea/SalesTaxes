using TEK.Infrastructure.Interfaces.DataContract;

namespace TEK.Infrastructure.Interfaces
{
    public interface ITaxCalculatorService
    {
        void ApplyTax(OrderProduct orderProduct);
    }
}
