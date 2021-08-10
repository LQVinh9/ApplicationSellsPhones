using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNhom.dto
{
    class ProductInCart
    {
        public Product product { get; set; }

        public int quantity { get; set; }

        public double price { get; set; }

        public ProductInCart()
        {

        }

        public ProductInCart(Product product, int quantity, double price)
        {
            this.product = product;
            this.quantity = quantity;
            this.price = price;
        }

        public override string ToString()
        {
            return "producID: " + product.productID + " ,quantity: " + quantity + " ,price: " + price;
        }
    }
}
