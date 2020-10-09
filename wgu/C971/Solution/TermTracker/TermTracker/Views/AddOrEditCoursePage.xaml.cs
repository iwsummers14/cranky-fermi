using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.Enum;
using TermTracker.Interfaces;
using TermTracker.Models;
using TermTracker.Utilities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [Description("AddOrEditCourse")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrEditCoursePage : ContentPage
    {
        private SQLiteAsyncConnection DataConnection { get; set; }

        private Course CurrentCourse { get; set; }

        private Instructor CurrentInstructor { get; set; }

        private List<string> StatusValues { get; set; }

        private UserOperation Operation { get; set; }

        public AddOrEditCoursePage()
        {
            InitializeComponent();
        }

        public AddOrEditCoursePage(ref SQLiteAsyncConnection dConn, int parentId)
        {
            InitializeComponent();
            InitializeViewAdd(dConn, parentId);

        }

        public AddOrEditCoursePage(ref SQLiteAsyncConnection dConn, Course courseToLoad)
        {
            InitializeComponent();
            InitializeViewEdit(dConn, courseToLoad);

        }

        private async void InitializeViewEdit(SQLiteAsyncConnection dConn, Course courseToLoad)
        {
            DataConnection = dConn;
            Operation = UserOperation.Edit;

            CurrentCourse = await DataConnection.GetAsync<Course>(courseToLoad.Id);
            CurrentInstructor = await DataConnection.GetAsync<Instructor>(courseToLoad.InstructorId);
            TitleText.Text = "Edit Course";
            PreparePicker();

            ent_InstructorName.Text = CurrentInstructor.Name;
            ent_InstructorPhone.Text = CurrentInstructor.PhoneNumber;
            ent_InstructorEmail.Text = CurrentInstructor.EmailAddress;
            
            ent_CourseCode.Text = CurrentCourse.CourseCode;
            ent_CourseTitle.Text = CurrentCourse.Title;
            dp_CourseStart.Date = CurrentCourse.StartDate;
            dp_CourseEnd.Date = CurrentCourse.EndDate;
            pk_CourseStatus.SelectedIndex = pk_CourseStatus.ItemsSource.IndexOf(CurrentCourse.Status);
            sw_NotificationsEnabled.IsToggled = CurrentCourse.NotificationsEnabled;
            ent_Notes.Text = CurrentCourse.Notes;
            
        }

        private void InitializeViewAdd(SQLiteAsyncConnection dConn, int parentId)
        {
            DataConnection = dConn;
            Operation = UserOperation.Add;

            CurrentInstructor = new Instructor();
            CurrentCourse = new Course()
            {
                TermId = parentId
            };
            TitleText.Text = "Add Course";
            PreparePicker();
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
            CurrentInstructor.Name = ent_InstructorName.Text;
            CurrentInstructor.PhoneNumber = ent_InstructorPhone.Text;
            CurrentInstructor.EmailAddress = ent_InstructorEmail.Text;

            if (Operation == UserOperation.Add)
            {
                await DataConnection.InsertAsync(CurrentInstructor);
            }
            else
            {
                await DataConnection.UpdateAsync(CurrentInstructor);
            }
                

            CurrentCourse.CourseCode = ent_CourseCode.Text;
            CurrentCourse.Title = ent_CourseTitle.Text;
            CurrentCourse.StartDate = dp_CourseStart.Date.Date;
            CurrentCourse.EndDate = dp_CourseEnd.Date.Date;
            CurrentCourse.Status = pk_CourseStatus.SelectedItem.ToString();
            CurrentCourse.InstructorId = CurrentInstructor.Id;
            CurrentCourse.Notes = ent_Notes.Text;

            if (Operation == UserOperation.Add)
            {
                await DataConnection.InsertAsync(CurrentCourse);
            }
            else
            {
                await DataConnection.UpdateAsync(CurrentCourse);
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
            pk_CourseStatus.ItemsSource = StatusValues;
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
            bool datesOk = false;
            bool emailOk = false;
            bool phoneOk = false;
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
                datesOk = InputValidator.IsValidDateRange(dp_CourseStart.Date, dp_CourseEnd.Date);
                emailOk = InputValidator.IsValidEmail(ent_InstructorEmail.Text);
                phoneOk = InputValidator.IsValidPhoneNumber(ent_InstructorPhone.Text);

                if (!datesOk)
                {
                    AlertUser("Input validation", "Start Date must be a date before the End Date.\nPlease choose a valid Start and End Date.");
                }

                if (!emailOk)
                {
                    AlertUser("Input validation", "The email address entered for Instructor Email was invalid.\nPlease enter a valid email address.");
                }

                if (!phoneOk)
                {
                    AlertUser("Input validation", "The phone number entered for Instructor Phone was invalid.\nPlease enter a phone number in the format 123-456-7890.");
                }
                
                if (datesOk && emailOk && phoneOk)
                {
                    validated = true;
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