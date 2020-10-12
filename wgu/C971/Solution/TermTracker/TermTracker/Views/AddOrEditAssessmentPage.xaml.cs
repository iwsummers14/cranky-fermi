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
    /// <summary>
    /// Entry view for assessments. Can be used to add or edit an assessment.
    /// </summary>
    [Description("AddOrEditAssessment")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrEditAssessmentPage : ContentPage
    {
        private SQLiteAsyncConnection DataConnection { get; set; }

        private Assessment CurrentAssessment { get; set; }

        private UserOperation Operation { get; set; }

        private List<string> StatusValues { get; set; }

        private List<string> TypeValues { get; set; }

        // default constructor
        public AddOrEditAssessmentPage()
        {
            InitializeComponent();
        }

        // constructor for add operation
        public AddOrEditAssessmentPage(ref SQLiteAsyncConnection dConn, int parentId)
        {
            InitializeComponent();
            InitializeViewAdd(dConn, parentId);

        }

        // constructor for edit operation
        public AddOrEditAssessmentPage(ref SQLiteAsyncConnection dConn, Assessment assessmentToLoad)
        {
            InitializeComponent();
            InitializeViewEdit(dConn, assessmentToLoad);

        }

        // initialize method for add operation
        private void InitializeViewAdd(SQLiteAsyncConnection dConn, int parentId)
        {
            DataConnection = dConn;
            Operation = UserOperation.Add;
            TitleText.Text = "Add Assessment";

            CurrentAssessment = new Assessment()
            {
                CourseId = parentId
            };
                        
            PreparePickers(parentId);
                                    
        }

        // initialize method for edit operation
        private async void InitializeViewEdit(SQLiteAsyncConnection dConn, Assessment assessmentToLoad)
        {
            DataConnection = dConn;
            Operation = UserOperation.Edit;
            TitleText.Text = "Edit Assessment";
            
            CurrentAssessment = await DataConnection.GetAsync<Assessment>(assessmentToLoad.Id);
            
            PreparePickers(CurrentAssessment.CourseId);
            
            ent_AssessmentTitle.Text = CurrentAssessment.Title;
            pk_AssessmentType.SelectedIndex = pk_AssessmentType.ItemsSource.IndexOf(CurrentAssessment.AssessmentType);
            dp_AssessmentStart.Date = CurrentAssessment.StartDate;
            dp_AssessmentEnd.Date = CurrentAssessment.EndDate;
            pk_AssessmentStatus.SelectedIndex = pk_AssessmentStatus.ItemsSource.IndexOf(CurrentAssessment.Status);
            sw_NotificationsEnabled.IsToggled = CurrentAssessment.NotificationsEnabled;
        }

        // event handler method, save button pressed 
        private void Save_Clicked(object sender, EventArgs e)
        {
            bool validated = ValidateInputs();
            if (validated) 
            {
                InsertOrUpdate(CloseForm);
            }
            
        }

        // event handler method, cancel button pressed 
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            CloseForm();
        }

        // async method to handle insertion or updating record in the database
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

        // async method to close the form 
        private async void CloseForm()
        {
            await Navigation.PopAsync();
        }

        // async method to fill the pickers with data from enum types used to control their selections
        private async void PreparePickers(int parentId)
        {
            TypeValues = EnumUtilities.EnumDescriptionsToList<AssessmentType>(typeof(AssessmentType));
            StatusValues = EnumUtilities.EnumDescriptionsToList<AssessmentStatus>(typeof(AssessmentStatus));

            var objectiveAssessments = await DataConnection.QueryAsync<Assessment>("SELECT * FROM Assessments WHERE CourseId = ? AND AssessmentType = 'Objective'", parentId);
            var performanceAssessments = await DataConnection.QueryAsync<Assessment>("SELECT * FROM Assessments WHERE CourseId = ? AND AssessmentType = 'Performance'", parentId);

            if (objectiveAssessments.Count >= 1 && Operation == UserOperation.Add)
            {
                TypeValues.RemoveAt(TypeValues.IndexOf("Objective"));
            }
            if (performanceAssessments.Count >= 1 && Operation == UserOperation.Add)
            {
                TypeValues.RemoveAt(TypeValues.IndexOf("Performance"));
            }
            
            pk_AssessmentStatus.ItemsSource = StatusValues;
            pk_AssessmentType.ItemsSource = TypeValues;
        }

        // async method to alert user of a condition
        private async void AlertUser(string title, string message)
        {
            await DisplayAlert($"{title}", $"{message}", "OK");
        }

        // input validation method using the InputVlaidator class to validate entries contain data, and that the data is valid
        private bool ValidateInputs()
        {

            // control variables
            bool textInputsNotNull = false;
            bool pickerInputsNotNull = false;
            bool dateInputsNotNull = false;
            bool validated = false;

            // get children of the input stack layout and send to list
            var layouts = InputsLayout.Children.Where(c => c.GetType() == typeof(StackLayout)).Cast<StackLayout>().ToList();
            var inputs = new List<View>();
            layouts.ForEach(sl => inputs.AddRange(sl.Children));

            // isolate each category of input as a list
            var textInputs = inputs.Where(input => input.GetType() == typeof(Entry)).Cast<Entry>().ToList();
            var pickerInputs = inputs.Where(input => input.GetType() == typeof(Picker)).Cast<Picker>().ToList();
            var dateInputs = inputs.Where(input => input.GetType() == typeof(DatePicker)).Cast<DatePicker>().ToList();

            // validate each category of input
            textInputsNotNull = InputValidator.InputsNotNull<Entry>(textInputs);
            pickerInputsNotNull = InputValidator.InputsNotNull<Picker>(pickerInputs);
            dateInputsNotNull = InputValidator.InputsNotNull<DatePicker>(dateInputs);
            
            // handle notifying user of invalid conditions
            if (textInputsNotNull && pickerInputsNotNull && dateInputsNotNull)
            {
                bool datesOk = InputValidator.IsValidDateRange(dp_AssessmentStart.Date, dp_AssessmentEnd.Date, true);

                if (datesOk)
                {
                    validated = true;
                }
                else
                {
                    AlertUser("Input validation", "Start Date must be a date before the End Date.\nPlease choose a valid Start and End Date.");
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