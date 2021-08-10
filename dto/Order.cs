using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNhom.dto
{
    class Order
    {
        public string orderID { get; set; }
        public string date { get; set; }
        public double total { get; set; }
        public string userID { get; set; }

        public Order(string orderID, string date, double total, string userID)
        {
            this.orderID = orderID;
            this.date = date;
            this.total = total;
            this.userID = userID;
        }
    }
}
