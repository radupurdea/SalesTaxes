using System.Collections.Generic;
using TEK.Infrastructure.Interfaces.DataContract;

namespace TEK.Infrastructure.Interfaces
{
    public interface ICartService
    {
        List<OrderProduct> Cart { get; }

        void AddToCart(Product selectedProduct);
        Receipt PreviewCart();
        Receipt Checkout();
        void ClearCart();
    }
}
