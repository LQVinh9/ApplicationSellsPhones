using ProjectNhom.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProjectNhom.dao
{
    class ProductDao
    {
        string strConnection;

        public string getConnectionString()
        {
            //string strConnection = @"server=DESKTOP-9L0KUCO\SQLEXPRESS;database=ShopPhone;uid=sa;pwd=123";
            //Amazon
            string strConnection = @"server=testdatabaseaws.c3lyzgwnjxrk.ap-southeast-1.rds.amazonaws.com;database=ShopPhone;uid=admin;pwd=12345678";
            return strConnection;
        }
        public ProductDao()
        {
            strConnection = getConnectionString();
        }

        public List<Product> getAllProduct()
        {
            List<Product> listProduct = new List<Product>();

            string sql = "select productID,productName,price,quantity,shortDescription,image,status,categoryID from Product";
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
                        string productID = reader.GetString(0);
                        string productName = reader.GetString(1);
                        double price = reader.GetDouble(2);
                        int quantity = reader.GetInt32(3);
                        string shortDescription = reader.GetString(4);
                        byte[] image = (byte[])reader["image"];
                        string status = reader.GetString(6);
                        string categoryID = reader.GetString(7);

                        Product product = new Product(productID, productName, price, quantity, shortDescription, image, status, categoryID);
                        listProduct.Add(product);
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

            return listProduct;
        }

        public List<Product> getAllProductByCategory(string categoryIDD)
        {
            List<Product> listProduct = new List<Product>();

            string sql = "select productID,productName,price,quantity,shortDescription,image,status,categoryID from Product where categoryID=@categoryIDD";
            SqlConnection cnn = new SqlConnection(strConnection);
            cnn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@categoryIDD", categoryIDD);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //string col1Value = reader["ColumnOneName"].ToString();

                        string productID = reader.GetString(0);
                        string productName = reader.GetString(1);
                        double price = reader.GetDouble(2);
                        int quantity = reader.GetInt32(3);
                        string shortDescription = reader.GetString(4);
                        byte[] image = (byte[])reader["image"];
                        string status = reader.GetString(6);
                        string categoryID = reader.GetString(7);

                        Product product = new Product(productID, productName, price, quantity, shortDescription, image, status, categoryID);

                        listProduct.Add(product);
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

            return listProduct;
        }

        public Product getProductByID(string ID)
        {
            Product product = null;

            SqlConnection cnn = new SqlConnection(strConnection);
            string sql = "select productID,productName,price,quantity,shortDescription,image,status,categoryID from Product where productID=@productID";
            cnn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@productID", ID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        string productID = reader.GetString(0);
                        string productName = reader.GetString(1);
                        double price = reader.GetDouble(2);
                        int quantity = reader.GetInt32(3);
                        string shortDescription = reader.GetString(4);
                        byte[] image = (byte[])reader["image"];
                        string status = reader.GetString(6);
                        string categoryID = reader.GetString(7);

                        product = new Product(productID, productName, price, quantity, shortDescription, image, status, categoryID);
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

            return product;
        }

        public bool addNewProduct(Product product)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Insert Product values(@productID,@productName,@price,@quantity,@shortDescription,@image,@status,@categoryID)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@productID", product.productID);
            cmd.Parameters.AddWithValue("@productName", product.productName);
            cmd.Parameters.AddWithValue("@price", product.price);
            cmd.Parameters.AddWithValue("@quantity", product.quantity);
            cmd.Parameters.AddWithValue("@shortDescription", product.shortDescription);
            cmd.Parameters.AddWithValue("@image", product.image);
            cmd.Parameters.AddWithValue("@status", product.status);
            cmd.Parameters.AddWithValue("@categoryID", product.categoryID);

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
            finally
            {
                cnn.Close();
            }
            return (count > 0);
        }

        public bool updateProduct(Product product)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Update Product set productName=@productName,price=@price,quantity=@quantity,shortDescription=@shortDescription,image=@image,status=@status,categoryID=@categoryID " +
                    "where productID=@productID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@productID", product.productID);
            cmd.Parameters.AddWithValue("@productName", product.productName);
            cmd.Parameters.AddWithValue("@price", product.price);
            cmd.Parameters.AddWithValue("@quantity", product.quantity);
            cmd.Parameters.AddWithValue("@shortDescription", product.shortDescription);
            cmd.Parameters.AddWithValue("@image", product.image);
            cmd.Parameters.AddWithValue("@status", product.status);
            cmd.Parameters.AddWithValue("@categoryID", product.categoryID);

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
            finally
            {
                cnn.Close();
            }
            return (count > 0);
        }

        public bool deleteProduct(string productID)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Update Product set status=@status " +
                    "where productID=@productID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@productID", productID);
            cmd.Parameters.AddWithValue("@status", "False");

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
            finally
            {
                cnn.Close();
            }
            return (count > 0);
        }


        //Tram search
        public List<Product> searchProductByName(string word)
        {
            List<Product> listProduct = new List<Product>();

            string sql = "select * from Product where productName like @word";
            SqlConnection cnn = new SqlConnection(strConnection);
            cnn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@word", "%" + word + "%");

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        string productID = reader.GetString(0);
                        string productName = reader.GetString(1);
                        double price = reader.GetDouble(2);
                        int quantity = reader.GetInt32(3);
                        string shortDescription = reader.GetString(4);
                        byte[] image = (byte[])reader["image"];
                        string status = reader.GetString(6);
                        string categoryID = reader.GetString(7);

                        Product product = new Product(productID, productName, price, quantity
                                                    , shortDescription, image, status, categoryID);

                        listProduct.Add(product);
                    }
                }
                else
                {
                    listProduct = null;
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
            return listProduct;
        }

        //Tram cart
        //public Product getProductByID(string productID)
        //{
        //    List<Product> listProduct = getAllProduct();
        //    for (int i = 0; i < listProduct.Count; i++)
        //    {
        //        if (listProduct[i].productID.Equals(productID))
        //        {
        //            return listProduct[i];
        //        }
        //    }
        //    return null;
        //}

        //Tram cart
        public bool updateQuantityOfProduct(string productID, int quantity)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Update Product set quantity=@quantity " +
                    "where productID=@productID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@productID", productID);
            cmd.Parameters.AddWithValue("@quantity", quantity);

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
    }
}


//public void PrintByteArray(byte[] bytes)
//{
//    var sb = new StringBuilder("new byte[] { ");
//    foreach (var b in bytes)
//    {
//        sb.Append(b + ", ");
//    }
//    sb.Append("}");
//    Console.WriteLine(sb.ToString());
//}
//string col1Value = reader["ColumnOneName"].ToString();
