using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNhom.dto
{
    class OrderDetail
    {
        public string orderDetailID { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public string orderID { get; set; }
        public string productID { get; set; }
        public byte[] image { get; set; }
        public string productName { get; set; }
        public double total { get; set; }
        public string date { get; set; }

        public OrderDetail(string orderDetailID, double price, int quantity, string orderID, string productID)
        {
            this.orderDetailID = orderDetailID;
            this.price = price;
            this.quantity = quantity;
            this.orderID = orderID;
            this.productID = productID;
        }

        public OrderDetail()
        {
        }


        public OrderDetail(byte[] image, string productName, string date, int quantity, double price, double total)
        {
            this.image = image;
            this.productName = productName;
            this.date = date;
            this.quantity = quantity;
            this.price = price;
            this.total = total;
        }
    }
}
