using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNhom.dto
{
    public class Category
    {
        public string categoryID { get; set; }

        public string categoryName { get; set; }

        public Category(string categoryID, string categoryName)
        {
            this.categoryID = categoryID;
            this.categoryName = categoryName;
        }

        public override string ToString()
        {
            return "categoryID: " + categoryID + ", categoryName: " + categoryName;
        }
    }
}
