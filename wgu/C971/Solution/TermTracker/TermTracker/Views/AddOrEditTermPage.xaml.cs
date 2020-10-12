using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TermTracker.Configuration;
using TermTracker.Interfaces;
using TermTracker.Enum;
using TermTracker.Utilities;
using TermTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    /// <summary>
    /// Entry view for terms. Can be used to add or edit a term.
    /// </summary>
    [Description("AddOrEditTerm")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrEditTermPage : ContentPage
    {
        private SQLiteAsyncConnection DataConnection { get; set; }

        private Term CurrentTerm { get; set; }

        private List<string> StatusValues { get; set; }

        private UserOperation Operation { get; set; }
        
        // default constructor
        public AddOrEditTermPage()
        {
            InitializeComponent();
        }

        // constructor for add operation
        public AddOrEditTermPage(ref SQLiteAsyncConnection dConn, Nullable<int> parentId = null)
        {
            InitializeComponent();
            InitializeViewAdd(dConn);
            
        }

        // constructor for edit operation
        public AddOrEditTermPage(ref SQLiteAsyncConnection dConn, Term termToLoad)
        {
            InitializeComponent();
            InitializeViewEdit(dConn, termToLoad);

        }

        // initialize method for add operation
        private void InitializeViewAdd(SQLiteAsyncConnection dConn)
        {
            DataConnection = dConn;
            Operation = UserOperation.Add;

            CurrentTerm = new Term();
            TitleText.Text = "Add Term";
            PreparePicker();

        }

        // initialize method for edit operation
        private async void InitializeViewEdit( SQLiteAsyncConnection dConn, Term termToLoad) 
        {
            DataConnection = dConn;
            Operation = UserOperation.Edit;

            CurrentTerm = await DataConnection.GetAsync<Term>(termToLoad.Id);
            TitleText.Text = "Edit Term";
            PreparePicker();

            ent_TermTitle.Text = CurrentTerm.Title;
            dp_TermStart.Date = CurrentTerm.StartDate;
            dp_TermEnd.Date = CurrentTerm.EndDate;
            pk_TermStatus.SelectedIndex = pk_TermStatus.ItemsSource.IndexOf(CurrentTerm.Status);

        }

        // event handler method for save button pressed
        private void Save_Clicked(object sender, EventArgs e)
        {
            bool validated = ValidateInputs();
            if (validated)
            {
                InsertOrUpdate(CloseForm);
            }
        }

        // event handler method for cancel button pressed
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            CloseForm();
        }

        // async method to handle insertion or updating of a record
        private async void InsertOrUpdate(Action callback)
        {
            CurrentTerm.Title = ent_TermTitle.Text;
            CurrentTerm.StartDate = dp_TermStart.Date.Date;
            CurrentTerm.EndDate = dp_TermEnd.Date.Date;
            CurrentTerm.Status = pk_TermStatus.SelectedItem.ToString();

            if (Operation == UserOperation.Add)
            {
                await DataConnection.InsertAsync(CurrentTerm);
            }
            else
            {
                await DataConnection.UpdateAsync(CurrentTerm);
            }
            
            callback();
        }

        // async method to close the form
        private async void CloseForm()
        {
            await Navigation.PopAsync();
        }

        // method to prepare picker entries from enum used to control values
        private void PreparePicker()
        {
            StatusValues = EnumUtilities.EnumDescriptionsToList<CourseStatus>(typeof(CourseStatus));
            pk_TermStatus.ItemsSource = StatusValues;
        }

        // async method to handle alerting user of error conditions
        private async void AlertUser(string title, string message)
        {
            await DisplayAlert($"{title}", $"{message}", "OK");
        }

        // input validation method using the InputValidator class
        private bool ValidateInputs()
        {

            // control vars
            bool textInputsNotNull = false;
            bool pickerInputsNotNull = false;
            bool dateInputsNotNull = false;
            bool validated = false;

            // get children of the input stacklayout and send to list
            var layouts = InputsLayout.Children.Where(c => c.GetType() == typeof(StackLayout)).Cast<StackLayout>().ToList();
            var inputs = new List<View>();
            layouts.ForEach(sl => inputs.AddRange(sl.Children));

            // isolate each type of input as a list
            var textInputs = inputs.Where(input => input.GetType() == typeof(Entry)).Cast<Entry>().ToList();
            var pickerInputs = inputs.Where(input => input.GetType() == typeof(Picker)).Cast<Picker>().ToList();
            var dateInputs = inputs.Where(input => input.GetType() == typeof(DatePicker)).Cast<DatePicker>().ToList();

            // validate each type of entry 
            textInputsNotNull = InputValidator.InputsNotNull<Entry>(textInputs);
            pickerInputsNotNull = InputValidator.InputsNotNull<Picker>(pickerInputs);
            dateInputsNotNull = InputValidator.InputsNotNull<DatePicker>(dateInputs);

            // notify user of error condition
            if (textInputsNotNull && pickerInputsNotNull && dateInputsNotNull)
            {
                bool datesOk = InputValidator.IsValidDateRange(dp_TermStart.Date, dp_TermEnd.Date);

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