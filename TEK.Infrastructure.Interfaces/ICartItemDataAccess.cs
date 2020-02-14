using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEK.Infrastructure.Interfaces.DataContract;

namespace TEK.Infrastructure.Interfaces
{
    public interface ICartItemDataAccess
    {
        List<OrderProduct> GetCart();

        void SaveCart(List<OrderProduct> cartItems);
    }
}
