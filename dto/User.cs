using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNhom.dto
{
    class User
    {
        public string userID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string status { get; set; }
        public string roleID { get; set; }

        public User(string userID, string userName, string password, string address, string phone, string status, string roleID)
        {
            this.userID = userID;
            this.userName = userName;
            this.password = password;
            this.address = address;
            this.phone = phone;
            this.status = status;
            this.roleID = roleID;
        }

        public User(string userID, string userName, string password, string address, string status, string roleID)
        {
            this.userID = userID;
            this.userName = userName;
            this.password = password;
            this.address = address;
            this.status = status;
            this.roleID = roleID;
        }

        public User()
        {
            userID = userName = password = address = phone = "";
        }

        public User(string userid, string username, string matkhau, string dchi, string sdt)
        {
            userID = userid;
            userName = username;
            password = matkhau;
            address = dchi;
            phone = sdt;
        }

        //true : hop le
        //false : ko hop le
        public bool checkFormatPassword()
        {
            if (password.Length < 8)
            {
                return false;
            }
            return true;
        }

        public string formatName()
        {
            userName = userName.Trim(); //Bỏ khoảng trắng đầu và cuối chuỗi

            //Nếu phát hiện 2 khoảng trắng trùng nhau liên tiếp thì xóa đi 1
            for (int i = 0; i < userName.Length; ++i)
            {
                if (userName[i] == ' ' && userName[i + 1] == ' ')
                {
                    userName = userName.Remove(i, 1);
                    i--;
                }
            }

            userName = userName.ToLower();

            //Xoa va insert ki tu dc viet hoa vao
            char c = userName[0];
            userName = userName.Remove(0, 1);
            userName = userName = userName.Insert(0, c.ToString().ToUpper());

            //Xử lí in hoa kí tự đầu mỗi từ sau khoảng trắng
            for (int i = 1; i < userName.Length; i++) //chạy vòng lặp từ vị trí 1 trở đi
            {
                if (userName[i] == ' ')//KT nếu s[i] = khoảng trắng => i + 1 Viết Hoa
                {
                    char c1 = userName[i + 1];
                    userName = userName.Remove(i + 1, 1);
                    userName = userName.Insert(i + 1, c1.ToString().ToUpper());
                }
            }
            return userName;
        }
    }
}
