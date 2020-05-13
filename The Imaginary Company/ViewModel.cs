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
using System.Windows.Input;
using Windows.Graphics.Imaging;
using Exe2009.Common;
using The_Imaginary_Company.View;

namespace The_Imaginary_Company
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            AddArticleCommand=new RelayCommand(AddArticle);
            SearchArticleCommand= new RelayCommand(Search);
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
        public ICommand SearchArticleCommand { get; set; }
        public ICommand AddArticleCommand { get; set; }
        public Article SearchResult = new Article(1111,1111,"default",1,1,"here","yes");
        public int TIC { get; set; }
        public int IAN { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public string Owner { get; set; }
        public void VMSetUser(string u,string p)
        {
            CurrentUser.SetUser(u,p);
        }

        public void AddArticle()
        {
            justcatalog.AddToList(new Article(TIC, IAN, Owner, Quantity, Weight, Location, Name));
        }

        public void Search()
        {
            if (TIC != 0)
                SearchResult= justcatalog.FindByTIC(TIC);
            else
            {
                SearchResult = IAN != 0 ? justcatalog.FindByIAN(IAN) : justcatalog.FindByLocation(Location);
            }

            OnPropertyChanged("SearchResult");
        }

        public bool VMCheckPassword()
        {
            return CurrentUser.ValidUser();
        }
        public ObservableCollection<Article> ArticleCollection => justcatalog.Articles;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
