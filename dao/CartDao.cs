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
    class CartDao
    {
        string strConnection;

        public string getConnectionString()
        {
            //string strConnection = @"server=DESKTOP-9L0KUCO\SQLEXPRESS;database=ShopPhone;uid=sa;pwd=123";
            //Amazon
            string strConnection = @"server=testdatabaseaws.c3lyzgwnjxrk.ap-southeast-1.rds.amazonaws.com;database=ShopPhone;uid=admin;pwd=12345678";
            return strConnection;
        }
        public CartDao()
        {
            strConnection = getConnectionString();
        }
        
        //Tram history
        public List<OrderDetail> displayAllOrderDetail(string userID)
        {
            List<OrderDetail> listOD = new List<OrderDetail>();

            string sql = "SELECT image, productName, date, OrderDetail.quantity, OrderDetail.price, total "
                            +"FROM OrderDetail "
                            +"INNER JOIN Product ON OrderDetail.productID = Product.productID "
                            +"INNER JOIN Orders ON OrderDetail.orderID = Orders.orderID "
                            +"WHERE userID = @userID";
            SqlConnection cnn = new SqlConnection(strConnection);
            cnn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@userID", userID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        byte[] image = (byte[])reader["image"];
                        string productName = reader.GetString(1);
                        string date = reader.GetDateTime(2).ToString();
                        int quantity = reader.GetInt32(3);
                        double price = reader.GetDouble(4);
                        double total = reader.GetDouble(5);

                        OrderDetail od = new OrderDetail(image, productName, date, quantity, price, total);

                        listOD.Add(od);

                    }
                }
                else
                {
                    listOD = null;
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
            return listOD;
        }

        //Tram cart
        public bool addNewOrderDetail(OrderDetail od)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Insert OrderDetail values(@orderDetailID,@price,@quantity,@orderID,@productID)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@orderDetailID", od.orderDetailID);
            cmd.Parameters.AddWithValue("@price", od.price);
            cmd.Parameters.AddWithValue("@quantity", od.quantity);
            cmd.Parameters.AddWithValue("@orderID", od.orderID);
            cmd.Parameters.AddWithValue("@productID", od.productID);

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
                count = 0;
            }
            finally
            {
                cnn.Close();
            }
            return (count > 0);
        }
        public bool addNewOrder(Order order)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Insert Orders values(@orderID,@date,@total,@userID)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@orderID", order.orderID);
            cmd.Parameters.AddWithValue("@date", order.date);
            cmd.Parameters.AddWithValue("@total", order.total);
            cmd.Parameters.AddWithValue("@userID", order.userID);

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
                count = 0;
            }
            finally
            {
                cnn.Close();
            }
            return (count > 0);
        }
        public List<OrderDetail> getAllOrderDetail()
        {
            List<OrderDetail> listOD = new List<OrderDetail>();

            string sql = "select orderDetailID, price, quantity, orderID, productID from OrderDetail";
            SqlConnection cnn = new SqlConnection(strConnection);
            cnn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {                       
                        string orderDetailID = reader.GetString(0);
                        double price = reader.GetDouble(1);
                        int quantity = reader.GetInt32(2);
                        string orderID = reader.GetString(3);
                        string productID = reader.GetString(4);

                        OrderDetail od = new OrderDetail(orderDetailID,price,quantity,orderID,productID);

                        listOD.Add(od);
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

            return listOD;
        }
        public OrderDetail getOrderDetailByID(string odID)
        {
            List<OrderDetail> listOD = getAllOrderDetail();
            for (int i = 0; i < listOD.Count; i++)
            {
                if (listOD[i].orderDetailID.Equals(odID))
                {
                    return listOD[i];
                }
            }
            return null;
        }
        public List<Order> getAllOrder()
        {
            List<Order> listOrder = new List<Order>();

            string sql = "select orderID, date, total, userID from Orders";
            SqlConnection cnn = new SqlConnection(strConnection);
            cnn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        string orderID = reader.GetString(0);
                        string date = reader.GetDateTime(1).ToString();
                        double total = reader.GetDouble(2);
                        string userID = reader.GetString(3);
                        
                        Order order = new Order(orderID, date, total, userID);

                        listOrder.Add(order);
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

            return listOrder;
        }
        public Order getOrderByID(string orderID)
        {
            List<Order> listOrder = getAllOrder();
            for (int i = 0; i < listOrder.Count; i++)
            {
                if (listOrder[i].orderID.Equals(orderID))
                {
                    return listOrder[i];
                }
            }
            return null;
        }
    }
}

