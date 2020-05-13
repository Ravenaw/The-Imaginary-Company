using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace InventoryLibrary
{
    public class Article
    {
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
        public int Weight { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return "";
        }

    }

    public class ArticleCatalog
    {
        private  static ObservableCollection<Article> List = new ObservableCollection<Article>();
        
        public ArticleCatalog()
        {
            //grab from server
        }

        public ObservableCollection<Article> GetAll()
        {
            return List;
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
        
        public void SetUser(string user,string pass)
        {
            Username = user;
            Password = pass;
        }
        public bool ValidUser()
        {
            if (Username == "ticAdmin" && Password == "ticPassword1")
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
