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
using The_Imaginary_Company.View;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace The_Imaginary_Company
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Menu : Page
    {
        public Menu()
        {
            this.InitializeComponent();
        }

        public void GoToPage(Type page)
        {
            Content.Navigate(page);
        }
        private void Pane_Click(object sender, RoutedEventArgs e)
        {
            SideMenu.IsPaneOpen = !SideMenu.IsPaneOpen;

        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(Catalog), e);
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(Add), e);
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(Search), e);
        }
        private void Details_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(Details), e);
        }

        private void ContactUs_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(Login), e);
        }

        private void Content_Navigated(object sender, NavigationEventArgs e)
        {
            Page destinationPage = e.Content as Page;
            if (destinationPage.GetType() == typeof(Login))
            {

                // Change property of destination page
                //(destinationPage as ProductPage).viewModel = viewModel;
            }

            if (destinationPage.GetType() == typeof(Login))
            {

                // Change property of destination page
                //(destinationPage as ShoppingCartPage).viewModel = viewModel;
            }

            if (destinationPage.GetType() == typeof(Login))
            {

                // Change property of destination page
                //(destinationPage as OrderHistory).viewModel = viewModel;
            }
        }
    }
}
