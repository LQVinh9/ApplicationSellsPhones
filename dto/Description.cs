using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNhom.dto
{
    class Description
    {
        public string descriptionID { get; set; }
        public int stt { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string contents { get; set; }
        public byte[] image { get; set; }
        public string productID { get; set; }

        public Description(string descriptionID, int stt, string type, string title, string contents, byte[] image, string productID)
        {
            this.descriptionID = descriptionID;
            this.stt = stt;
            this.type = type;
            this.title = title;
            this.contents = contents;
            this.image = image;
            this.productID = productID;
        }
    }
}
