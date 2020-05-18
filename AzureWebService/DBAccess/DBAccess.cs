using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using InventoryLibrary;
using System.Collections.ObjectModel;

namespace AzureWebService.DBAccess
{
    public class DBAccess
    {
        public const string connectionString = @"Server=tcp:the-imaginary-company.database.windows.net,1433;Initial Catalog=Inventory;Persist Security Info=False;User ID=ticAdmin;Password=ticPassword1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public ObservableCollection<Article> GetAllArticles()
        {
            string query = "select * from articles";
            ObservableCollection<Article> mylist = new ObservableCollection<Article>();
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

        public Article GetArticleByTIC(int id)
        {
            string query = "select * from Articles where TIC=@id";
            Article returnArticle = new Article();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    returnArticle.TIC = reader.GetInt32(0);
                    returnArticle.IAN = reader.GetInt32(1);
                    returnArticle.Owner = reader.GetString(2);
                    returnArticle.Name = reader.GetString(3);
                    returnArticle.Quantity = reader.GetInt32(4);
                    returnArticle.Weight = reader.GetInt32(5);
                    returnArticle.Location = reader.GetString(6);
                }
                return returnArticle;
            }
        }

        public Article GetArticleByIAN(int id)
        {
            string query = "select * from Articles where IAN=@id";
            Article returnArticle = new Article();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    returnArticle.TIC = reader.GetInt32(0);
                    returnArticle.IAN = reader.GetInt32(1);
                    returnArticle.Owner = reader.GetString(2);
                    returnArticle.Name = reader.GetString(3);
                    returnArticle.Quantity = reader.GetInt32(4);
                    returnArticle.Weight = reader.GetInt32(5);
                    returnArticle.Location = reader.GetString(6);
                }
                return returnArticle;
            }
        }

        public Article GetArticleByLocation(string loc)
        {
            string query = "select * from Articles where Location=@loc";
            Article returnArticle = new Article();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@loc", loc);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    returnArticle.TIC = reader.GetInt32(0);
                    returnArticle.IAN = reader.GetInt32(1);
                    returnArticle.Owner = reader.GetString(2);
                    returnArticle.Name = reader.GetString(3);
                    returnArticle.Quantity = reader.GetInt32(4);
                    returnArticle.Weight = reader.GetInt32(5);
                    returnArticle.Location = reader.GetString(6);
                }
                return returnArticle;
            }
        }
        public void createArticle(Article article)
        {
            string query = "insert into Articles(TIC, IAN, Name, Owner, Location, Weight, Quantity) values(@tic, @ian, @name, @owner, @location, @weight, @quantity)"; //query here...

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@tic", article.TIC);
                command.Parameters.AddWithValue("@ian", article.IAN);
                command.Parameters.AddWithValue("@name", article.Name);
                command.Parameters.AddWithValue("@owner", article.Owner);
                command.Parameters.AddWithValue("@location", article.Location);
                command.Parameters.AddWithValue("@weight", article.Weight);
                command.Parameters.AddWithValue("@quantity", article.Quantity);
                //parameters here...
                int affectedRows = command.ExecuteNonQuery();
            }
        }

        public void deleteArticle(int id)
        {
            string query = "delete form Articles where TIC=@id"; //query here...
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
            string query = "update Articles set TIC=@tic, IAN=@ian, Name=@name, Owner=@owner, Location=@location, Weight=@weight, Quantity=@quantity where TIC=@id"; //query here...
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@tic", article.TIC);
                command.Parameters.AddWithValue("@ian", article.IAN);
                command.Parameters.AddWithValue("@name", article.Name);
                command.Parameters.AddWithValue("@owner", article.Owner);
                command.Parameters.AddWithValue("@location", article.Location);
                command.Parameters.AddWithValue("@weight", article.Weight);
                command.Parameters.AddWithValue("@quantity", article.Quantity);
                int affectedRows = command.ExecuteNonQuery();
            }
        }
    }
}