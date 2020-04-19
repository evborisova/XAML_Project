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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AccountsManager.Views
{
    public sealed partial class EditAssignment : ContentDialog
    {
        private Model.Assignment assignment;

        private Action<Model.Assignment> onButtonClick;
        public EditAssignment(Model.Assignment assignment, Action<Model.Assignment> onButtonClick)
        {
  
            this.InitializeComponent();
        //    assignment.StartDate = DateTime.Now;
            this.assignment = assignment;
            this.DataContext = assignment;
            this.onButtonClick = onButtonClick;

            if (assignment.StartDate.Year > 1900)
            {
                StartDatePicker.Date = assignment.StartDate;
            }
            if (assignment.EndDate.Year > 1900)
            {
                EndDatePicker.Date = assignment.EndDate;
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            onButtonClick(assignment);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void DatePicker_StartDateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            assignment.StartDate = e.NewDate.DateTime;
        }
        private void DatePicker_EndDateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            assignment.EndDate = e.NewDate.DateTime;
        }
    }
}
