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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace The_Imaginary_Company
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Burger : Page
    {
        public Burger()
        {
            this.InitializeComponent();
        }
        private void Pane_Click(object sender, RoutedEventArgs e)
        {
            SideMenu.IsPaneOpen = !SideMenu.IsPaneOpen;

        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(MainPage), e);

        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(MainPage), e);

        }
        private void History_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(MainPage), e);

        }
        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(MainPage), e);

        }

        private void ContactUs_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(MainPage), e);
        }

        private void Content_Navigated(object sender, NavigationEventArgs e)
        {
            Page destinationPage = e.Content as Page;
            if (destinationPage.GetType() == typeof(MainPage))
            {

                // Change property of destination page
                //(destinationPage as ProductPage).viewModel = viewModel;
            }

            if (destinationPage.GetType() == typeof(MainPage))
            {

                // Change property of destination page
                //(destinationPage as ShoppingCartPage).viewModel = viewModel;
            }

            if (destinationPage.GetType() == typeof(MainPage))
            {

                // Change property of destination page
                //(destinationPage as OrderHistory).viewModel = viewModel;
            }
        }
    }
}
