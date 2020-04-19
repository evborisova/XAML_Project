using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
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

namespace AccountsManager.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ManageCompanies : Page
    {
        private AccountsManager.Client.Client client = new AccountsManager.Client.Client();

        public ManageCompanies()
        {
            this.InitializeComponent();
        }

        private async void UpdateCompanies()
        {
            UpdateText.Text = "Updating...";
            UpdateText.Visibility = Visibility.Visible;
            Companies.Items.Clear();
            try
            {
                List<Model.Company> comps = await client.GetCompanies();

                foreach (var com in comps)
                {
                    Companies.Items.Add(com);
                }
                UpdateText.Visibility = Visibility.Collapsed;
            } catch (Exception d)
            {
                UpdateText.Text = "Error communicating with server";
                return;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCompanies();
        }
    }
}
