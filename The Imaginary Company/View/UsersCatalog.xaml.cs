using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using The_Imaginary_Company.Common;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace The_Imaginary_Company.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserCatalog : Page
    {
        public UserCatalog()

        { // this comes predefined
            this.InitializeComponent();
            //this is the binding for the hole page
            DataContext = ViewModel.Instance;
            //this is the binding for the listview
            ContactsListView.ItemsSource = ViewModel.Instance.UsersCollection;
            ContactsListView.SelectedItem = ViewModel.Instance.SelectedUser;

        }

        // tis is the method that makes the info for the user (the stack pannel) visible when you select an user from the listview
        private void ContactsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContactsListView.SelectedItem == null)
            {
                Contacts.Visibility = Visibility.Collapsed;
            }
            if (ContactsListView.SelectedItem != null)
            {
                Contacts.Visibility = Visibility.Visible;
            }
        }
    }
}
