using ProjectNhom.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProjectNhom.dao
{
    class CategoryDao
    {
        string strConnection;

        public string getConnectionString()
        {
            //string strConnection = @"server=DESKTOP-9L0KUCO\SQLEXPRESS;database=ShopPhone;uid=sa;pwd=123";
            //Amazon
            string strConnection = @"server=testdatabaseaws.c3lyzgwnjxrk.ap-southeast-1.rds.amazonaws.com;database=ShopPhone;uid=admin;pwd=12345678";
            return strConnection;
        }
        public CategoryDao()
        {
            strConnection = getConnectionString();
        }

        public List<Category> getAllCategory()
        {
            List<Category> listCategory = new List<Category>();

            string sql = "select categoryID,categoryName from Category";
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
                        string categoryID = reader.GetString(0);
                        string categoryName = reader.GetString(1);

                        Category category = new Category(categoryID, categoryName);
                        listCategory.Add(category);
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
            return listCategory;
        }
    }
}
