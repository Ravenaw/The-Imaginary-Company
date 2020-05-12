using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLibrary
{
    public class Article
    {
        public int TIC { get; set; }
        public int IAN { get; set; }
        public string Owner { get; set; }
        public int Quantity { get; set; }
        public int Weight { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return "";
        }

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
