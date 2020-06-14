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
                    Article theArticle = new Article
                    {
                        TIC = reader.GetString(0),
                        IAN = reader.GetString(1),
                        Owner = reader.GetString(2),
                        Name = reader.GetString(3),
                        Quantity = reader.GetInt32(4),
                        Weight = reader.GetDouble(5),
                        Location = reader.GetString(6)
                    };

                    mylist.Add(theArticle);
                }
                return mylist;
            }
        }

        public Article GetArticleByTIC(string id)
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
                    returnArticle.TIC = reader.GetString(0);
                    returnArticle.IAN = reader.GetString(1);
                    returnArticle.Owner = reader.GetString(2);
                    returnArticle.Name = reader.GetString(3);
                    returnArticle.Quantity = reader.GetInt32(4);
                    returnArticle.Weight = reader.GetDouble(5);
                    returnArticle.Location = reader.GetString(6);
                }
                return returnArticle;
            }
        }

        public Article GetArticleByIAN(string id)
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
                    returnArticle.TIC = reader.GetString(0);
                    returnArticle.IAN = reader.GetString(1);
                    returnArticle.Owner = reader.GetString(2);
                    returnArticle.Name = reader.GetString(3);
                    returnArticle.Quantity = reader.GetInt32(4);
                    returnArticle.Weight = reader.GetDouble(5);
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
                    returnArticle.TIC = reader.GetString(0);
                    returnArticle.IAN = reader.GetString(1);
                    returnArticle.Owner = reader.GetString(2);
                    returnArticle.Name = reader.GetString(3);
                    returnArticle.Quantity = reader.GetInt32(4);
                    returnArticle.Weight = reader.GetDouble(5);
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

        public void deleteArticle(string id)
        {
            string query = "delete from Articles where TIC=@id"; //query here...
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                int affectedRows = command.ExecuteNonQuery();
            }
        }

        public void updateArticle(string id, Article article)
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
        
        public ObservableCollection<User> GetAllUsers()
        {
            string query = "select * from [User]";
            ObservableCollection<User> mylist = new ObservableCollection<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User theUser = new User()
                    {
                        Username = reader.GetString(0),
                        Password = reader.GetString(1),
                        Name = reader.IsDBNull(2) ? "N/A" : reader.GetString(2),
                        PhoneNo = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                        Email = reader.IsDBNull(4) ? "N/A" : reader.GetString(4),
                        Address = reader.IsDBNull(5) ? "N/A" : reader.GetString(5)
                    };
                    mylist.Add(theUser);
                }
                return mylist;
            }

        }

        public void createUser(User user)
        {
            string query = "insert into User(Username, Password, Name, PhoneNo., Email, Address) values(@username, @password, @name, @phoneno, @email, @address)"; //query here...

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@phoneno", user.PhoneNo);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@address", user.Address);
                //parameters here...
                int affectedRows = command.ExecuteNonQuery();
            }
        }
        public void deleteUser(string username)
        {
            string query = "delete from User where Username=@username"; //query here...
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@username", username);
                int affectedRows = command.ExecuteNonQuery();
            }
        }
        public User GetUser(string username)
        {
            string query = "select * from User where Username=@username";
            User returnUser = new User();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    returnUser.Username = reader.GetString(0);
                    returnUser.Password = reader.GetString(1);
                    returnUser.Name = reader.GetString(2);
                    returnUser.PhoneNo = reader.GetInt32(4);
                    returnUser.Email = reader.GetString(5);
                    returnUser.Address = reader.GetString(6);
                }
                return returnUser;
            }
        }
    }
}