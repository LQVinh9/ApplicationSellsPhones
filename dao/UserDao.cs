using ProjectNhom.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNhom.dao
{
    class UserDao
    {
        string strConnection;

        public string getConnectionString()
        {
            //string strConnection = @"server=DESKTOP-9L0KUCO\SQLEXPRESS;database=ShopPhone;uid=sa;pwd=123";
            //Amazon
            string strConnection = @"server=testdatabaseaws.c3lyzgwnjxrk.ap-southeast-1.rds.amazonaws.com;database=ShopPhone;uid=admin;pwd=12345678";
            return strConnection;
        }
        public UserDao()
        {
            strConnection = getConnectionString();
        }

        //Nhi
        public List<User> getAllUser()
        {
            List<User> listUser = new List<User>();

            string sql = "select * from Users";
            SqlConnection cnn = new SqlConnection(strConnection);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string userID = reader.GetString(0);
                    string userName = reader.GetString(1);
                    string password = reader.GetString(2);
                    string address = reader.GetString(3);
                    string status = reader.GetString(4);
                    string roleID = reader.GetString(5);

                    User user = new User(userID, userName, password, address, status, roleID);

                    Console.WriteLine(user.ToString());

                    listUser.Add(user);
                }
            }

            return listUser;
        }

        public User getUserByID(string userID)
        {
            User user = null;

            string sql = "select userID,userName,password,address,phone,status,roleID from Users where userID=@userID";
            SqlConnection cnn = new SqlConnection(strConnection);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@userID", userID);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        string id = reader.GetString(0);
                        string userName = reader.GetString(1);
                        string password = reader.GetString(2);
                        string address = reader.GetString(3);
                        string phone = reader.GetString(4);
                        string status = reader.GetString(5);
                        string roleID = reader.GetString(6);

                        user = new User(id, userName, password, address, phone, status, roleID);
                    }
                }
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                cnn.Close();
            }
            return user;
        }

        //Nhi
        public bool addNewUser(User user)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Insert Users values(@userID,@userName,@password,@address,@phone,@status,@roleID)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@userID", user.userID);
            cmd.Parameters.AddWithValue("@userName", user.userName);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.Parameters.AddWithValue("@address", user.address);
            cmd.Parameters.AddWithValue("@phone", user.phone);
            cmd.Parameters.AddWithValue("@status", "True");
            cmd.Parameters.AddWithValue("@roleID", "C");

            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count;
            try
            {
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                count = 0;
            }
            return (count > 0);
        }
    }
}
