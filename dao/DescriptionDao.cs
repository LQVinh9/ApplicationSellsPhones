using ProjectNhom.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ProjectNhom.dao
{
    class DescriptionDao
    {
        string strConnection;

        public string getConnectionString()
        {
            //string strConnection = @"server=DESKTOP-9L0KUCO\SQLEXPRESS;database=ShopPhone;uid=sa;pwd=123";
            //Amazon
            string strConnection = @"server=testdatabaseaws.c3lyzgwnjxrk.ap-southeast-1.rds.amazonaws.com;database=ShopPhone;uid=admin;pwd=12345678";
            return strConnection;
        }
        public DescriptionDao()
        {
            strConnection = getConnectionString();
        }

        public bool addNewDescription(Description description)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Insert Description values(@descriptionID,@stt,@type,@title,@contents,@image,@productID)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@descriptionID", description.descriptionID);
            cmd.Parameters.AddWithValue("@stt", description.stt);
            cmd.Parameters.AddWithValue("@type", description.type);
            cmd.Parameters.AddWithValue("@title", description.title ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@contents", description.contents ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@image", description.image ?? SqlBinary.Null);
            cmd.Parameters.AddWithValue("@productID", description.productID);
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

        public Description getDescriptionByID(string ID)
        {
            Description description = null;

            SqlConnection cnn = new SqlConnection(strConnection);
            string sql = "select descriptionID,stt,type,title,contents,image,productID from Description where descriptionID=@descriptionID";
            cnn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@descriptionID", ID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        string descriptionID = reader.GetString(0);
                        int stt = reader.GetInt32(1);
                        string type = reader.GetString(2);
                        string title = reader.GetString(3);
                        string contents = reader.GetString(4);
                        byte[] image = (byte[])reader["image"];
                        string productID = reader.GetString(6);

                        description = new Description(descriptionID, stt, type, title, contents, image, productID);
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

            return description;
        }

        public List<Description> getDescriptionByProductID(string ID)
        {
            List<Description> listDescription= new List<Description>();

            string sql = "select descriptionID,stt,type,title,contents,image,productID " +
                    "from Description "+
                    "where productID = @productID " +
                    "order by stt asc ";
            SqlConnection cnn = new SqlConnection(strConnection);
            cnn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@productID", ID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string descriptionID = reader.GetString(0);
                        int stt = reader.GetInt32(1);
                        string type = reader.GetString(2);

                        string title = null;
                        if (!reader.IsDBNull(3)) title = reader.GetString(3);

                        string contents = null;
                        if (!reader.IsDBNull(4)) contents = reader.GetString(4);

                        byte[] image = null;
                        if (!reader.IsDBNull(5)) image = (byte[])reader["image"];

                        string productID = reader.GetString(6);

                        Description description = new Description(descriptionID, stt, type, title, contents, image, productID);

                        listDescription.Add(description);
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

            return listDescription;
        }

        public bool deleteDescriptionOfProduct(string productID)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "DELETE FROM Description " +
                    "where productID=@productID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@productID", productID);

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
