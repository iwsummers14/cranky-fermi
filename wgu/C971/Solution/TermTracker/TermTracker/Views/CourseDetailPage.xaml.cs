using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.Factory;
using TermTracker.Models;
using TermTracker.Enum;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [Description("ViewDetailCourse")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseDetailPage : ContentPage
    {

        private ViewFactory Factory { get => new ViewFactory(); }

        private SQLiteAsyncConnection DataConnection { get; set; }

        private ObservableCollection<Assessment> AssessmentsList;

        private Course CurrentCourse { get; set; }


        public CourseDetailPage(ref SQLiteAsyncConnection dConn, Course courseToLoad)
        {
            InitializeComponent();
            CurrentCourse = courseToLoad;
            DataConnection = dConn;

        }
        protected override async void OnAppearing()
        {
            var instructor = await DataConnection.QueryAsync<Instructor>("SELECT * FROM Instructors WHERE Id = ?", CurrentCourse.InstructorId);
            var assessments = await DataConnection.QueryAsync<Assessment>("SELECT * FROM Assessments WHERE CourseId = ?", CurrentCourse.Id);

            AssessmentsList = new ObservableCollection<Assessment>(assessments);
            AssessmentsListView.ItemsSource = AssessmentsList;
            TitleText.Text = $"Course Detail for {CurrentCourse.CourseCode}\n{CurrentCourse.Title}";

            lbl_CourseStartDate.Text = CurrentCourse.StartDate.ToShortDateString();
            lbl_CourseEndDate.Text = CurrentCourse.EndDate.ToShortDateString();
            lbl_CourseNotifications.Text = CurrentCourse.NotificationsEnabled ? "Yes" : "No";
            lbl_InstructorName.Text = instructor.First().Name;
            lbl_InstructorPhone.Text = instructor.First().PhoneNumber;
            lbl_InstructorEmail.Text = instructor.First().EmailAddress;

        }
        private async void ViewCellAssessment_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssessmentDetailPage());
        }

        private void EditCourse_Clicked(object sender, EventArgs e)
        {

        }

        private void DeleteCourse_Clicked(object sender, EventArgs e)
        {

        }

        private async void AddAssessment_Clicked(object sender, EventArgs e)
        {
            var view = Factory.GetEntryView<Assessment>(UserOperation.Add, DataConnection, null, CurrentCourse.Id);
            await Navigation.PushAsync(view);

        }
    }
}