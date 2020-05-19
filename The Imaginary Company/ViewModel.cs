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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using The_Imaginary_Company.Common;

namespace The_Imaginary_Company
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            AddArticleCommand = new RelayCommand(AddArticle);
            SearchArticleCommand = new RelayCommand(Search);
            DeleteCommand = new RelayCommand(Delete);
            GoToEditCommand = new RelayCommand(GoToEdit);
            EditArticleCommand = new RelayCommand(Edit);
            CancelOnEditCommand = new RelayCommand(CancelOnEdit);
            UpdateDb();
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
        private RestWorker Worker = new RestWorker();
        private User CurrentUser = new User();
        private ArticleCatalog justcatalog = new ArticleCatalog();
        public ObservableCollection<Article> AllArticles { get { return justcatalog.GetAll(); } }

        public ICommand SearchArticleCommand { get; set; }
        public ICommand EditArticleCommand { get; set; }
        public ICommand AddArticleCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand GoToEditCommand { get; set; }
        public ICommand CancelOnEditCommand { get; set; }

        public Article SearchResult = new Article();
        public Article Temp = new Article();



        public int TIC { get; set; }
        public int IAN { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Quantity { get; set; }
        private string _loc;
        public string Location { get { return _loc; } set { _loc = value.Trim().ToUpper(); } }
        public string Owner { get; set; }
        public async Task UpdateDb()
        {
            ObservableCollection<Article> temp = await Worker.GetArticlesAsync();
            justcatalog.Update(temp);
        }
        public void VMSetUser(string u, string p)
        {
            CurrentUser.SetUser(u, p);
        }

        public void AddArticle()
        {
            Temp = new Article(TIC, IAN, Owner, Quantity, Weight, Location, Name);
            Worker.CreateArticle(Temp);
            SearchResult = Temp;
            Navigate(typeof(Details));
        }

        public async void Search()
        {
            if (TIC != 0)
                SearchResult = await Worker.GetArticleAsync(TIC);
            else
            {
                if (IAN != 0)
                    SearchResult = await Worker.GetArticleByIanAsync(IAN);
                else
                {
                    if (!Location.Equals(""))
                        SearchResult = await Worker.GetArticleByLocationAsync(Location);
                }
            }

            Navigate(typeof(Details));
            OnPropertyChanged("SearchResult");
        }

        public void Delete()
        {
            Worker.DeleteArticle(SearchResult.TIC);
            //UpdateDb();

            SearchResult.Name += " - Deleted";
            Navigate(typeof(Details));
        }

        public void GoToEdit()
        {
            Temp = SearchResult;
            Navigate(typeof(EditItem));
        }
        public void Edit()
        {
            Worker.UpdateArticle(Temp.TIC, SearchResult);
            //UpdateDb();
            Navigate(typeof(Details));
        }

        public void CancelOnEdit()
        {
            Navigate(typeof(Details));
        }

        public void Navigate(Type NewPage)
        {
            var Page = (Frame)Window.Current.Content;
            (Page.Content as Menu).GoToPage(NewPage);
        }
        //just for details page
        public string quantity
        {
            get { return Quantity.ToString("F1"); }
        }
        //.........
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
