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
    [Description("ViewDetailAssessment")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentDetailPage : ContentPage
    {
        private ViewFactory Factory { get => new ViewFactory(); }

        private SQLiteAsyncConnection DataConnection { get; set; }

        private Assessment CurrentAssessment { get; set; }


        public AssessmentDetailPage(ref SQLiteAsyncConnection dConn, Assessment assessmentToLoad)
        {
            InitializeComponent();
            CurrentAssessment = assessmentToLoad;
            DataConnection = dConn;

        }
        protected override async void OnAppearing()
        {
            TitleText.Text = $"Assessment Detail\n{CurrentAssessment.Title}\n{CurrentAssessment.AssessmentType} Assessment";

            lbl_AssessmentStatus.Text = CurrentAssessment.Status;
            lbl_AssessmentStartDate.Text = CurrentAssessment.StartDate.ToShortDateString();
            lbl_AssessmentEndDate.Text = CurrentAssessment.EndDate.ToShortDateString();
            lbl_AssessmentNotifications.Text = CurrentAssessment.NotificationsEnabled ? "Yes" : "No";
 
        }

        private async void EditAssessment_Clicked(object sender, EventArgs e)
        {
            var view = Factory.GetEntryView<Assessment>(UserOperation.Edit, DataConnection, CurrentAssessment);
            await Navigation.PushAsync(view);
        }

        private void DeleteAssessment_Clicked(object sender, EventArgs e)
        {

        }
    }
}