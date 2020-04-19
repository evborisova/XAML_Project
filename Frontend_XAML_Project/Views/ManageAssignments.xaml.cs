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
    public sealed partial class ManageAssignments : Page
    {
        private AccountsManager.Client.Client client = new AccountsManager.Client.Client();

        public ManageAssignments()
        {
            this.InitializeComponent();
        }

        private async void UpdateAssignments()
        {
            UpdateText.Text = "Updating...";
            UpdateText.Visibility = Visibility.Visible;
            Assignments.Items.Clear();
            try
            {
                List<Model.Assignment> assignments = await client.GetAssignments();

                foreach (var assignment in assignments)
                {
                    Assignments.Items.Add(assignment);
                }
                UpdateText.Visibility = Visibility.Collapsed;
            } catch (Exception d)
            {
                UpdateText.Text = "Error communicating with server" + d.Message;
                return;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAssignments();
        }

        private async void Assignments_ItemClick(object sender, ItemClickEventArgs e)
        {
            ContentDialog editDialog = new EditAssignment(
                (Model.Assignment)e.ClickedItem,
                (assignment) => {
                    client.UpdateAssignment(assignment);
                }
            );
            var result = await editDialog.ShowAsync();
            UpdateAssignments();
        }

        private async void AddAssignment(object sender, RoutedEventArgs e)
        {
            ContentDialog editDialog = new EditAssignment(
                new Model.Assignment(),
                (assignment) => {
                    client.AddAssignment(assignment);
                });
            var result = await editDialog.ShowAsync();
            UpdateAssignments();
        }
    }
}
