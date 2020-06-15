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
using Microsoft.Toolkit.Extensions;
using Windows.UI.Popups;
using System.ServiceModel.Channels;
using System.Security.Cryptography.X509Certificates;
using UserCatalog = InventoryLibrary.UserCatalog;

namespace The_Imaginary_Company
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            AddArticleCommand = new RelayCommand(AddArticle);
            SearchArticleCommand = new RelayCommand(Search);
            DeleteCommand = new RelayCommand(DisplayDeleteItemDialog);
            GoToEditCommand = new RelayCommand(GoToEdit);
            EditArticleCommand = new RelayCommand(Edit);
            CancelOnEditCommand = new RelayCommand(CancelOnEdit);
            DeleteUserCommand= new RelayCommand(DeleteUser);
            _selectedUser = null;
            //UpdateDb();
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
        public User CurrentUser = new User();
        public ArticleCatalog AllArticles = new ArticleCatalog();
        public UserCatalog AllUsers = new UserCatalog();
        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;

            set
            {
                _selectedUser = value;
                OnPropertyChanged();
                DeleteUserCommand.RaiseCanExecuteChanged();
            }
        }
        //public ObservableCollection<Article> AllArticles { get { return justcatalog.GetAll(); } }

        public ICommand SearchArticleCommand { get; set; }
        public ICommand EditArticleCommand { get; set; }
        public ICommand AddArticleCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand GoToEditCommand { get; set; }
        public ICommand CancelOnEditCommand { get; set; }
        public RelayCommand DeleteUserCommand { get; set; }

        public Article SearchResult = new Article();
        public Article Temp = new Article();



        public string TIC { get; set; }
        public string IAN { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Quantity { get; set; }
        private string _loc;
        public string Location { get { return _loc; } set { _loc = value.Trim().ToUpper(); } }
        public string Owner { get; set; }
        public async Task UpdateDb()
        {
            ObservableCollection<Article> temp = await Worker.GetArticlesAsync();
            ObservableCollection<User> temp1 = await Worker.GetUsersAsync();
            AllArticles.Update(temp);
            AllUsers.Update(temp1);
            OnPropertyChanged("AllArticles");
            OnPropertyChanged("AllUsers");
        }
        public void VMSetUser(string u, string p)
        {
            CurrentUser.SetUser(u, p);
        }

        public void AddArticle()
        {
            Temp = new Article(TIC, IAN, Owner, Quantity, Weight, Location, Name);
            if (Temp.TIC.IsNumeric() && Temp.isIANnumeric() && Temp.Quantity > 0 && Temp.Weight > 0 && (Temp.IAN.Length == 8 || Temp.IAN.Length == 16) && Temp.Location.Length == 6)
            {
                Worker.CreateArticle(Temp);
                SearchResult = Temp;
                Navigate(typeof(Details));
            }
            else
            {
                InputError();
            }

        }
       
        public async void Search()
        {
            try
            {
                if (TIC != "")
                    SearchResult = await Worker.GetArticleAsync(TIC);
                else
                {
                    if (IAN != "")
                        SearchResult = await Worker.GetArticleByIanAsync(IAN);
                    else
                    {
                        if (!Location.Equals(""))
                            SearchResult = await Worker.GetArticleByLocationAsync(Location);
                    }
                }
                if (SearchResult.Weight == 0)
                {
                    NoResultsError();
                }
                else
                {
                    Navigate(typeof(Details));
                    OnPropertyChanged("SearchResult");
                }
            }
            catch (Newtonsoft.Json.JsonSerializationException e)
            {
                InputError();
            }
        }

        public void Delete()
        {
            Worker.DeleteArticle(SearchResult.TIC);
            //UpdateDb();

            SearchResult.Name += " - Deleted";
            Navigate(typeof(Details));
        }
        public void DeleteUser()
        {
            Worker.DeleteUser(SelectedUser.Username);
            NavigateForAdmin(typeof(View.UserCatalog));

            SelectedUser = null;
        }

        

        public async void DisplayDeleteItemDialog()
        {
            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "Delete item permanently?",
                Content = "If you delete this item, you won't be able to recover it. Do you want to delete it?",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                Delete();
            }
        }

        public void GoToEdit()
        {
            Temp = SearchResult;
            Navigate(typeof(EditItem));
        }

        public void Edit()
        {
            if (SearchResult.isIANnumeric() && SearchResult.Weight > 0 && (SearchResult.IAN.Length == 8 || SearchResult.IAN.Length == 16) && SearchResult.Location.Length == 6)
            {
                Worker.UpdateArticle(Temp.TIC, SearchResult);
                //UpdateDb();
                Navigate(typeof(Details));
            }
            else
            {
                InputError();
            }
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
        public void NavigateForAdmin(Type NewPage)
        {
            var Page = (Frame)Window.Current.Content;
            (Page.Content as MenuForAdmin).GoToPage(NewPage);
        }
        //just for details page
        public string quantity
        {
            get { return Quantity.ToString("F1"); }
        }
        //.........
        public async Task<bool> VMCheckPassword()
        {
            User islogedin = await Worker.GetUserAsync(CurrentUser.Username);
            if (CurrentUser.Password == islogedin.Password)
            {
                return true;
            }
            else return false;
        }

        public async void loginError()
        {
            ContentDialog loginError = new ContentDialog()
            {
                Title = "Error",
                Content = "Invalid username or password.",
                CloseButtonText = "OK"
            };
            await loginError.ShowAsync();
        }

        public async void InputError()
        {
            ContentDialog error = new ContentDialog()
            {
                Title = "Error",
                Content = "Invalid input.",
                CloseButtonText = "OK"
            };
            await error.ShowAsync();
        }

        public async void NoResultsError()
        {
            ContentDialog error = new ContentDialog()
            {
                Title = "Not found",
                Content = "404 - No article found",
                CloseButtonText = "OK"
            };
            await error.ShowAsync();
        }
        //what is this?
        //public ObservableCollection<Article> ArticleCollection => AllArticles.Articles;
        public ObservableCollection<User> UsersCollection => AllUsers.GetAll();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
