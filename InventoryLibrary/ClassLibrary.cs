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

    public class Somethingelse
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
}
