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
            InsertOrUpdate(CloseForm);
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
            CurrentCourse.StartDate = dp_CourseStart.Date;
            CurrentCourse.EndDate = dp_CourseEnd.Date;
            CurrentCourse.Status = pk_CourseStatus.SelectedItem.ToString();
            CurrentCourse.InstructorId = CurrentInstructor.Id;

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
    }
}