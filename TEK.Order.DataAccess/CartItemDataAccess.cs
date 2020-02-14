using System.Collections.Generic;
using TEK.Infrastructure.Interfaces;
using TEK.Infrastructure.Interfaces.DataContract;

namespace TEK.Order.DataAccess
{
    public class CartItemDataAccess : ICartItemDataAccess
    {
        private List<OrderProduct> Cart;

        public CartItemDataAccess()
        {
            Cart = new List<OrderProduct>();
        }

        public List<OrderProduct> GetCart()
        {
            return Cart;
        }

        public void SaveCart(List<OrderProduct> cartItems)
        {
            Cart = cartItems;
        }
    }
}
