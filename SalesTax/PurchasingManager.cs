using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class PurchasingManager
    {
        public PurchasingManager()
        {
            
        }

        public OrderProduct AddToCart(Product selectedProduct)
        {
            return new OrderProduct()
            {
                Product = selectedProduct,
                Quantity = 1
            };
        }

        public List<OrderProduct> Checkout(List<Product> selectedProducts)
        {
            //step 0
            //create orderProduct

            //step 1
            //calculate extended amount
            //substeps:
            //calculate discount etc
            //calculate tax



            //step 3
            //return order product
            return new List<OrderProduct>();
        }
    }
}
