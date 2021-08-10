using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNhom.dto
{
    public class Product
    { 
        public string productID { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public string shortDescription { get; set; }
        public byte[] image { get; set; }
        public string status { get; set; }
        public string categoryID { get; set; }

        public Product(string productID, string productName, double price, int quantity, string shortDescription, byte[] image, string status, string categoryID)
        {
            this.productID = productID;
            this.productName = productName;
            this.price = price;
            this.quantity = quantity;
            this.shortDescription = shortDescription;
            this.image = image;
            this.status = status;
            this.categoryID = categoryID;
        }
    }
}
