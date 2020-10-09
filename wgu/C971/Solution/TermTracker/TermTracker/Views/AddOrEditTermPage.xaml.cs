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
    [Description("AddOrEditTerm")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrEditTermPage : ContentPage
    {
        private SQLiteAsyncConnection DataConnection { get; set; }

        private Term CurrentTerm { get; set; }

        private List<string> StatusValues { get; set; }

        private UserOperation Operation { get; set; }
        
        public AddOrEditTermPage()
        {
            InitializeComponent();
        }

        public AddOrEditTermPage(ref SQLiteAsyncConnection dConn, Nullable<int> parentId = null)
        {
            InitializeComponent();
            InitializeViewAdd(dConn);
            
        }

        public AddOrEditTermPage(ref SQLiteAsyncConnection dConn, Term termToLoad)
        {
            InitializeComponent();
            InitializeViewEdit(dConn, termToLoad);

        }

        private void InitializeViewAdd(SQLiteAsyncConnection dConn)
        {
            DataConnection = dConn;
            Operation = UserOperation.Add;

            CurrentTerm = new Term();
            TitleText.Text = "Add Term";
            PreparePicker();

        }

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

        private async void CloseForm()
        {
            await Navigation.PopAsync();
        }

        private void PreparePicker()
        {
            StatusValues = EnumUtilities.EnumDescriptionsToList<CourseStatus>(typeof(CourseStatus));
            pk_TermStatus.ItemsSource = StatusValues;
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
                bool datesOk = InputValidator.IsValidDateRange(dp_TermStart.Date, dp_TermEnd.Date);

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