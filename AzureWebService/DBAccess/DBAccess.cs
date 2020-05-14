using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using InventoryLibrary;

namespace AzureWebService.DBAccess
{
    public class DBAccess
    {
        public const string connectionString = @"Server=tcp:the-imaginary-company.database.windows.net,1433;Initial Catalog=Inventory;Persist Security Info=False;User ID=ticAdmin;Password=ticPassword1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public List<Article> GetAllArticles()
        {
            string query = "select * from articles";
            List<Article> mylist = new List<Article>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Article theArticle = new Article();
                    theArticle.TIC = reader.GetInt32(0);
                    theArticle.IAN = reader.GetInt32(1);
                    theArticle.Owner = reader.GetString(2);
                    theArticle.Name = reader.GetString(3);
                    theArticle.Quantity = reader.GetInt32(4);
                    theArticle.Weight = reader.GetInt32(5);
                    theArticle.Location = reader.GetString(6);

                    mylist.Add(theArticle);
                }
                return mylist;
            }
        }

        public Article GetArticle(int id)
        {
            string query = "";
            Article returnArticle = new Article();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                //thing here...
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //things here...
                }
                return returnArticle;
            }
        }

        public void createArticle(Article article)
        {
            string query = ""; //query here...

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                //things here...
                int affectedRows = command.ExecuteNonQuery();
            }
        }

        public void deleteArticle(int id)
        {
            string query = ""; //query here...
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                int affectedRows = command.ExecuteNonQuery();
            }
        }

        public void updateArticle(int id, Article article)
        {
            string query = ""; //query here...
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                //things here...
                int affectedRows = command.ExecuteNonQuery();
            }
        }
    }
}