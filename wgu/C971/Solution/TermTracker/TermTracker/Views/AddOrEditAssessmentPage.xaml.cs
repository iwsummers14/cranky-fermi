using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.Interfaces;
using TermTracker.Models;
using TermTracker.Utilities;
using TermTracker.Enum;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [Description("AddOrEditAssessment")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrEditAssessmentPage : ContentPage
    {
        private SQLiteAsyncConnection DataConnection { get; set; }

        private Assessment CurrentAssessment { get; set; }

        private List<string> StatusValues { get; set; }

        private List<string> TypeValues { get; set; }

        public AddOrEditAssessmentPage()
        {
            InitializeComponent();
        }

        public AddOrEditAssessmentPage(ref SQLiteAsyncConnection dConn, int parentId)
        {
            InitializeComponent();
            InitializeViewAdd(dConn, parentId);

        }

        public AddOrEditAssessmentPage(ref SQLiteAsyncConnection dConn, Assessment assessmentToLoad)
        {
            InitializeComponent();
            InitializeViewEdit(dConn, assessmentToLoad);

        }

        private void InitializeViewAdd(SQLiteAsyncConnection dConn, int parentId)
        {
            DataConnection = dConn;
            CurrentAssessment = new Assessment()
            {
                CourseId = parentId
            };
            TitleText.Text = "Add Assessment";
            PreparePickers();
        }

        private async void InitializeViewEdit(SQLiteAsyncConnection dConn, Assessment assessmentToLoad)
        {
            DataConnection = dConn;
            CurrentAssessment = await DataConnection.GetAsync<Assessment>(assessmentToLoad.Id);
            TitleText.Text = "Edit Assessment";
            PreparePickers();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            InsertOrReplace(CloseForm);
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            CloseForm();
        }

        private async void InsertOrReplace(Action callback)
        {
            CurrentAssessment.Title = ent_AssessmentName.Text;
            CurrentAssessment.StartDate = dp_AssessmentStart.Date;
            CurrentAssessment.EndDate = dp_AssessmentEnd.Date;
            CurrentAssessment.AssessmentType = pk_AssessmentType.SelectedItem.ToString();
            CurrentAssessment.Status = pk_AssessmentStatus.SelectedItem.ToString();
            CurrentAssessment.NotificationsEnabled = sw_NotificationsEnabled.IsToggled;

            await DataConnection.InsertOrReplaceAsync(CurrentAssessment, typeof(Assessment));

            callback();
        }

        private async void CloseForm()
         {
            await Navigation.PopAsync();
        }

        private void PreparePickers()
        {
            TypeValues = EnumUtilities.EnumDescriptionsToList<AssessmentType>(typeof(AssessmentType));
            StatusValues = EnumUtilities.EnumDescriptionsToList<AssessmentStatus>(typeof(AssessmentStatus));
            pk_AssessmentStatus.ItemsSource = StatusValues;
            pk_AssessmentType.ItemsSource = TypeValues;
        }

    }
}