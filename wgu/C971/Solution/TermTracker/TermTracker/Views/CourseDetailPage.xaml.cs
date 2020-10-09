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
using Xamarin.Essentials;
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
            lbl_Notes.Text = CurrentCourse.Notes;

        }
        
        private async void EditCourse_Clicked(object sender, EventArgs e)
        {
            var view = Factory.GetEntryView<Course>(UserOperation.Edit, DataConnection, CurrentCourse);
            await Navigation.PushAsync(view);
        }

        private async void DeleteCourse_Clicked(object sender, EventArgs e)
        {
            var confirmation = await DisplayAlert($"Delete Course", $"Are you sure you want to delete course \n'{CurrentCourse.CourseCode} - {CurrentCourse.Title}'?", "Yes", "No");
            
            if (confirmation == true)
            {
                await DataConnection.DeleteAsync<Course>(CurrentCourse.Id);
                await Navigation.PopAsync();
            }
        }

        private async void AddAssessment_Clicked(object sender, EventArgs e)
        {
            var view = Factory.GetEntryView<Assessment>(UserOperation.Add, DataConnection, null, CurrentCourse.Id);
            await Navigation.PushAsync(view);

        }

        private async void AssessmentsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var assessment = (Assessment)(e.Item);
            var view = Factory.GetDetailView<Assessment>(DataConnection, assessment);
            await Navigation.PushAsync(view);
        }

        private async void ShareNotes_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(
                new ShareTextRequest() 
                { 
                    Text = $"Check out my TermTracker notes for {CurrentCourse.CourseCode} - {CurrentCourse.Title}! \n\n{CurrentCourse.Notes}",
                    Title = $"Share course notes for course {CurrentCourse.CourseCode} - {CurrentCourse.Title}?"
                });
        }
    }
}