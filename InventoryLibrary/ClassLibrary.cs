using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace InventoryLibrary
{
    public class Article
    {
        //create an empty article for future implementation (or to work with it without parametres) 
        public Article()
        {

        }
        //create an article with parametres
        public Article(string tic, string ian, string owner, int quantity, double weight, string location, string name)
        {
            //assigning value to the parameter
            TIC = tic;
            IAN = ian;
            Owner = owner;
            Quantity = quantity;
            Weight = weight;
            Location = location;
            Name = name;
        }
        //declatation of the parameters
        public string TIC { get; set; }
        public string IAN { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return $"TIC:{TIC}, IAN: {IAN}, Owner: {Owner}, Quantity: {Quantity}, Weight: {Weight}, Location: {Location} ";
        }
        //only numbers
        public bool isIANnumeric()
        {
            bool itIs = true;
            if (IAN != null)
            {
                foreach (char n in IAN)
                {
                    if (n >= '0' && n <= '9')
                    {

                    }
                    else
                    {
                        itIs = false;
                    }
                }
            }

            return itIs;
        }
    }

    public class ArticleCatalog
    {
        //sget info from database as alist of articles
        private static ObservableCollection<Article> List = new ObservableCollection<Article>()
        {};

        public ArticleCatalog()
        {
        }
        //used to get all the articles from the list
        public ObservableCollection<Article> GetAll()
        {
            return List;
        }
        //used to update the list in case we delete, edit or add an article on the server
        public void Update(ObservableCollection<Article> NewL)
        {
            List = NewL;
        }
        /*
        public void AddToList(Article NewArt)
        {
            List.Add(NewArt);
        }

        public void RemoveFromList(Article Art)
        {
            List.Remove(Art);
        }

        public Article FindByTIC(string tic)
        {
            return List.FirstOrDefault(x => x.TIC == tic);
        }
        public Article FindByIAN(string ian)
        {
            return List.FirstOrDefault(x => x.IAN == ian);
        }
        public Article FindByLocation(string location)
        {
            return List.FirstOrDefault(x => x.Location == location);
        }

        //what is this for? is it important?
        //public ObservableCollection<Article> Articles => List;
        */
    }


    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public User(string username, string password, string name, int phoneno, string email, string address )
        {
            Username = username;
            Password = password;
            Name = name;
            PhoneNo = phoneno;
            Email = email;
            Address = address;
        }

        public User()
        {
        }
        //sets the valuse: the username and password for the current user, the one that you created when you typed the credentials in the view
        public void SetUser(string user, string pass)
        {
            Username = user;
            Password = pass;
        }
       
        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Phone Number: {PhoneNo}, Address:{Address}";
        }

    }

    public class UserCatalog
    {
        private static ObservableCollection<User> List = new ObservableCollection<User>() { };
        public UserCatalog() {}
        public ObservableCollection<User> GetAll()
        {
            return List;
        }

        public void Update(ObservableCollection<User> NewL)
        {
            List = NewL;
        }
    }
}
