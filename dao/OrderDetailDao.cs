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
    class OrderDetailDao
    {
        string strConnection;

        public string getConnectionString()
        {
            //string strConnection = @"server=DESKTOP-9L0KUCO\SQLEXPRESS;database=ShopPhone;uid=sa;pwd=123";
            //Amazon
            string strConnection = @"server=testdatabaseaws.c3lyzgwnjxrk.ap-southeast-1.rds.amazonaws.com;database=ShopPhone;uid=admin;pwd=12345678";
            return strConnection;
        }
        public OrderDetailDao()
        {
            strConnection = getConnectionString();
        }

        public List<OrderDetail> getAllOrderDetail()
        {
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();

            string sql = "select orderDetailID,price,quantity,orderID,productID from OrderDetail";
            SqlConnection cnn = new SqlConnection(strConnection);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string orderDetailID = reader.GetString(0);
                        float price = (float)reader.GetDouble(1);
                        int quantity = reader.GetInt32(2);
                        string orderID = reader.GetString(3);
                        string productID = reader.GetString(4);

                        OrderDetail orderDetail = new OrderDetail(orderDetailID, price, quantity, orderID, productID);
                        listOrderDetail.Add(orderDetail);
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
            return listOrderDetail;
        }
    }
}
