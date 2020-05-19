using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace InventoryLibrary
{
    public class Article
    {
        public Article()
        {

        }
        public Article(int tic, int ian, string owner, int quantity, int weight, string location, string name)
        {
            TIC = tic;
            IAN = ian;
            Owner = owner;
            Quantity = quantity;
            Weight = weight;
            Location = location;
            Name = name;
        }
        public int TIC { get; set; }
        public int IAN { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return "";
        }

    }

    public class ArticleCatalog
    {
        private static ObservableCollection<Article> List = new ObservableCollection<Article>()
        {};

        public ArticleCatalog()
        {
        }

        public ObservableCollection<Article> GetAll()
        {
            return List;
        }

        public void Update(ObservableCollection<Article> NewL)
        {
            List = NewL;
        }

        public void AddToList(Article NewArt)
        {
            List.Add(NewArt);
        }

        public void RemoveFromList(Article Art)
        {
            List.Remove(Art);
        }

        public Article FindByTIC(int tic)
        {
            return List.FirstOrDefault(x => x.TIC == tic);
        }
        public Article FindByIAN(int ian)
        {
            return List.FirstOrDefault(x => x.IAN == ian);
        }
        public Article FindByLocation(string location)
        {
            return List.FirstOrDefault(x => x.Location == location);
        }

        //what is this for? is it important?
        //public ObservableCollection<Article> Articles => List;
    }


    public class User
    {
        private string Username { get; set; }
        private string Password { get; set; }
        private string Name { get; set; }
        private int PhoneNo { get; set; }
        private string Email { get; set; }

        public User(string username, string password, int phoneno, string email )
        {
            Username = username;
            Password = password;
            PhoneNo = phoneno;
            Email = email;
        }

        public User()
        {
        }

        public static List<User> UsersList = new List<User>()
        {
            new User("Aukse", "124Bla", 246412, "aukse@blabla.dot"),
            new User("Marcell", "124Pla", 89626, "marcell@blabla.dot"),
            new User("Alex", "yes", 5962524, "alex@blabla.dot"),
            new User("David","124Blu", 5453152, "david@blabla.dot"),
            new User("Andrea", "124Dbu",1754612, "andreea@blabla.dot"),
            new User("ticAdmin","ticPassword1", 545658, "admin@blabla.dot")
        };

        public void SetUser(string user, string pass)
        {
            Username = user;
            Password = pass;
        }
        public bool ValidUser()
        {
            if (UsersList.First(x => x.Username == this.Username && x.Password == this.Password) != null)
            { return true; }

            else
                return false;

        }
        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Phone Number: {PhoneNo}";
        }

    }
}
