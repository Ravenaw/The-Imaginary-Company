using InventoryLibrary;
using Microsoft.Toolkit.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using The_Imaginary_Company.View;

namespace The_Imaginary_Company
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
        }

        public static ViewModel Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly ViewModel instance = new ViewModel();
        }

        private User CurrentUser = new User();
        private ArticleCatalog justcatalog = new ArticleCatalog();
        public void VMSetUser(string u,string p)
        {
            CurrentUser.SetUser(u,p);
        }

        public bool VMCheckPassword()
        {
            return CurrentUser.ValidUser();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
