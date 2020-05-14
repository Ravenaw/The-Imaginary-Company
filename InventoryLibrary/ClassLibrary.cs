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
        {
            new Article(2001,5641,"Dolce Gusto", 5, 10, "Row 3", "Capsules")
        };

        public ArticleCatalog()
        {
            //grab from server
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
            return List.First(x => x.TIC == tic);
        }
        public Article FindByIAN(int ian)
        {
            return List.First(x => x.IAN == ian);
        }
        public Article FindByLocation(string location)
        {
            return List.First(x => x.Location == location);
        }

        public ObservableCollection<Article> Articles => List;
    }


    public class User
    {
        private string Username { get; set; }
        private string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User()
        {
        }

        public string userName { get; set; }
        public string password { get; set; }

        public static List<User> UsersList = new List<User>()
        {
            new User("Aukse", "124Bla"),
            new User("Marcell", "124Pla"),
            new User("Vlad", "124Gla"),
            new User("David","124Blu"),
            new User("Andrea", "124Dbu")
        };

        public void SetUser(string user, string pass)
        {
            Username = user;
            Password = pass;
        }
        public bool ValidUser()
        {
          if (Username == "ticAdmin" && Password == "ticPassword1" || Username == "Aukse" && Password == "124Bla" || Username == "Marcell" && Password == "124Pla" || Username == "Vlad" && Password == "124Gla" || Username == "David" && Password == "124Blu" || Username == "Andrea" && Password == "124Dbu")
                return true;
            else
                return false;

        }
        public override string ToString()
        {
            return "You are not allowed to view this";
        }

    }
}
