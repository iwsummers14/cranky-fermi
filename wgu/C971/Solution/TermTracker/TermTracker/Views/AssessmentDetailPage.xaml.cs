using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.Enum;
using TermTracker.Factory;
using TermTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    /// <summary>
    /// Detail view for Assessments. User can edit or delete the assessment from this page.
    /// </summary>
    [Description("ViewDetailAssessment")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentDetailPage : ContentPage
    {
        private ViewFactory Factory { get => new ViewFactory(); }

        private SQLiteAsyncConnection DataConnection { get; set; }

        private Assessment CurrentAssessment { get; set; }

        // constructor
        public AssessmentDetailPage(ref SQLiteAsyncConnection dConn, Assessment assessmentToLoad)
        {
            InitializeComponent();
            CurrentAssessment = assessmentToLoad;
            DataConnection = dConn;

        }

        // override of OnAppearing method to load the values
        protected override async void OnAppearing()
        {
            CurrentAssessment = await DataConnection.GetAsync<Assessment>(CurrentAssessment.Id);
            TitleText.Text = $"Assessment Detail\n{CurrentAssessment.Title}\n{CurrentAssessment.AssessmentType} Assessment";

            lbl_AssessmentStatus.Text = CurrentAssessment.Status;
            lbl_AssessmentStartDate.Text = CurrentAssessment.StartDate.ToShortDateString();
            lbl_AssessmentEndDate.Text = CurrentAssessment.EndDate.ToShortDateString();
            lbl_AssessmentNotifications.Text = CurrentAssessment.NotificationsEnabled ? "Yes" : "No";
 
        }

        // event handler method for the edit button pressed
        private async void EditAssessment_Clicked(object sender, EventArgs e)
        {
            var view = Factory.GetEntryView<Assessment>(UserOperation.Edit, DataConnection, CurrentAssessment);
            await Navigation.PushAsync(view);
        }

        // event handler method for the delete button pressed - includes a confirmation pop up
        private async void DeleteAssessment_Clicked(object sender, EventArgs e)
        {
            var confirmation = await DisplayAlert($"Delete Assessment", $"Are you sure you want to delete \n{CurrentAssessment.AssessmentType} Assessment '{CurrentAssessment.Title}'?", "Yes", "No");

            if (confirmation == true)
            {
                await DataConnection.DeleteAsync<Assessment>(CurrentAssessment.Id);
                await Navigation.PopAsync();
            }
        }
    }
}