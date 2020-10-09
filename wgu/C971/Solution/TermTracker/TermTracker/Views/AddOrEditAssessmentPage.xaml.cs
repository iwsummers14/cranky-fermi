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

        private UserOperation Operation { get; set; }

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
            Operation = UserOperation.Add;

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
            Operation = UserOperation.Edit;

            CurrentAssessment = await DataConnection.GetAsync<Assessment>(assessmentToLoad.Id);

            TitleText.Text = "Edit Assessment";
            PreparePickers();

            ent_AssessmentTitle.Text = CurrentAssessment.Title;
            pk_AssessmentType.SelectedIndex = pk_AssessmentType.ItemsSource.IndexOf(CurrentAssessment.AssessmentType);
            dp_AssessmentStart.Date = CurrentAssessment.StartDate;
            dp_AssessmentEnd.Date = CurrentAssessment.EndDate;
            pk_AssessmentStatus.SelectedIndex = pk_AssessmentStatus.ItemsSource.IndexOf(CurrentAssessment.Status);
            sw_NotificationsEnabled.IsToggled = CurrentAssessment.NotificationsEnabled;

        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            bool validated = ValidateInputs();
            if (validated) 
            {
                InsertOrUpdate(CloseForm);
            }
            
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            CloseForm();
        }

        private async void InsertOrUpdate(Action callback)
        {

            CurrentAssessment.Title = ent_AssessmentTitle.Text;
            CurrentAssessment.StartDate = dp_AssessmentStart.Date.Date;
            CurrentAssessment.EndDate = dp_AssessmentEnd.Date.Date;
            CurrentAssessment.AssessmentType = pk_AssessmentType.SelectedItem.ToString();
            CurrentAssessment.Status = pk_AssessmentStatus.SelectedItem.ToString();
            CurrentAssessment.NotificationsEnabled = sw_NotificationsEnabled.IsToggled;

            if (Operation == UserOperation.Add)
            {
                await DataConnection.InsertAsync(CurrentAssessment);
            }
            else
            {
                await DataConnection.UpdateAsync(CurrentAssessment);
            }

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

        private async void AlertUser(string title, string message)
        {
            await DisplayAlert($"{title}", $"{message}", "OK");
        }

        private bool ValidateInputs()
        {
            bool textInputsNotNull = false;
            bool pickerInputsNotNull = false;
            bool dateInputsNotNull = false;
            bool validated = false;

            var layouts = InputsLayout.Children.Where(c => c.GetType() == typeof(StackLayout)).Cast<StackLayout>().ToList();
            var inputs = new List<View>();
            layouts.ForEach(sl => inputs.AddRange(sl.Children));

            var textInputs = inputs.Where(input => input.GetType() == typeof(Entry)).Cast<Entry>().ToList();
            var pickerInputs = inputs.Where(input => input.GetType() == typeof(Picker)).Cast<Picker>().ToList();
            var dateInputs = inputs.Where(input => input.GetType() == typeof(DatePicker)).Cast<DatePicker>().ToList();

            textInputsNotNull = InputValidator.InputsNotNull<Entry>(textInputs);
            pickerInputsNotNull = InputValidator.InputsNotNull<Picker>(pickerInputs);
            dateInputsNotNull = InputValidator.InputsNotNull<DatePicker>(dateInputs);
            

            if (textInputsNotNull && pickerInputsNotNull && dateInputsNotNull)
            {
                bool datesOk = InputValidator.IsValidDateRange(dp_AssessmentStart.Date, dp_AssessmentEnd.Date, true);

                if (datesOk)
                {
                    validated = true;
                }
                else
                {
                    AlertUser("Input validation", "Start Date must be a date before the End Date. Please choose a valid Start and End Date.");
                }
            }
            else
            {
                AlertUser("Input validation", "All inputs must have values.\nPlease enter data in all fields.");
            }

            return validated;
        }

    }
}