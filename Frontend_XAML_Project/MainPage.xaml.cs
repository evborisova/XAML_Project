using AccountsManager.Views;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AccountsManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {             
            this.InitializeComponent();
            
            MainFrame.Navigate(typeof(HomeView));
            MenuItems.SelectedIndex = 0;
            TitleTextBlock.Text = "Home";
        }

        private void ToggleMenu(object sender, RoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
        }

        public void NavigateAssignment()
        {
            MainFrame.Navigate(typeof(ManageAssignments));
            TitleTextBlock.Text = "Assignments";
            AssignmentMenuItem.IsSelected = true;
        }

        public void NavigateCompanies()
        {
            MainFrame.Navigate(typeof(ManageCompanies));
            TitleTextBlock.Text = "Companies";
            CompanyMenuItem.IsSelected = true;
        }

        private void MenuChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomeMenuItem.IsSelected)
            {
                MainFrame.Navigate(typeof(HomeView));
                TitleTextBlock.Text = "Home";
            }
            else if (AssignmentMenuItem.IsSelected)
            {
                NavigateAssignment();
            }
            else if (CompanyMenuItem.IsSelected)
            {
                NavigateCompanies();
            }
        }

        private void CloseMenu(object sender, PointerRoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = false;
        }

        private void OpenMenu(object sender, PointerRoutedEventArgs e)
        {
            if (e.KeyModifiers == Windows.System.VirtualKeyModifiers.Control)
            {
                MenuSplitView.IsPaneOpen = true;
            }
        }
    }
}
