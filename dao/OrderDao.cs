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
    class OrderDao
    {
        string strConnection;

        public string getConnectionString()
        {
            //string strConnection = @"server=DESKTOP-9L0KUCO\SQLEXPRESS;database=ShopPhone;uid=sa;pwd=123";
            //Amazon
            string strConnection = @"server=testdatabaseaws.c3lyzgwnjxrk.ap-southeast-1.rds.amazonaws.com;database=ShopPhone;uid=admin;pwd=12345678";
            return strConnection;
        }
        public OrderDao()
        {
            strConnection = getConnectionString();
        }

        public Order getOrderByID(string orderID)
        {
            Order order = null;

            string sql = "select orderID,date,total,userID from Orders where orderID=@orderID";
            SqlConnection cnn = new SqlConnection(strConnection);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@orderID", orderID);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id = reader.GetString(0);
                        string date = reader.GetDateTime(1).ToString();
                        float total = (float)reader.GetDouble(2);
                        string userID = reader.GetString(3);

                        order = new Order(id, date, total, userID);
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
            return order;
        }
    }
}
