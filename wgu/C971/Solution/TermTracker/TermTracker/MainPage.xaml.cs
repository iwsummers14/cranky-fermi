using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.Configuration;
using TermTracker.Events;
using TermTracker.Interfaces;
using TermTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TermTracker.ViewModels;
using TermTracker.Views;
using TermTracker.Factory;
using TermTracker.Enum;
using System.Threading;
using TermTracker.Utilities;

namespace TermTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private INotificationManager NotificationManager;

        private int NotificationNumber = 0;

        List<Tuple<Type, int>> NotificationsFired = new List<Tuple<Type, int>>();

        private SQLiteAsyncConnection DataConnection;

        private ObservableCollection<Term> TermsList;

        private BackgroundWorker NotificationWorker { get; set; }

        private ViewFactory Factory { get => new ViewFactory(); }

        public string ViewTitle = "Term Tracker";

        public MainPage()
        {
            InitializeComponent();
            NotificationManager = DependencyService.Get<INotificationManager>();
            NotificationWorker = new BackgroundWorker();
            NotificationWorker.DoWork += ProcessNotifications;

            DataConnection = new Startup().DataConnection;
            TitleText.Text = ViewTitle;
            
        }

        protected override async void OnAppearing() 
        {
            var terms = await DataConnection.Table<Term>().ToListAsync();
            TermsList = new ObservableCollection<Term>(terms);
            TermsListView.ItemsSource = TermsList;
                        
            if (NotificationWorker.IsBusy == false)
            {
                NotificationWorker.RunWorkerAsync();
            }
            
        }

        private void ProcessNotifications(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);

            DateTime today = DateTime.Today;

            CreateAndLogNotifications<Course>(today, NotificationType.Starts);
            CreateAndLogNotifications<Course>(today, NotificationType.IsDue);
            CreateAndLogNotifications<Assessment>(today, NotificationType.Starts);
            CreateAndLogNotifications<Assessment>(today, NotificationType.IsDue);

        }

        private void CreateAndLogNotifications<T>(DateTime date, NotificationType notificationType) where T : class, new()
        {
            Type type = typeof(T);
            var starting = GetEventsByStartDate<T>(date);

            foreach (T item in starting.Result)
            {

                switch (type.Name)
                {
                    case nameof(Course):
                        CreateCourseNotification(item, notificationType);
                        break;

                    case nameof(Assessment):
                        CreateAssessmentNotification(item, notificationType);
                        break;

                    default:
                        throw new InvalidOperationException("Notifications are not supported for this type.");
                        break;
                }
                
            }
                        
        }

        private void CreateCourseNotification(object item, NotificationType notificationType)
        {
            var course = (Course)item;
            var type = course.GetType();
            var lookupTuple = new Tuple<Type, int>(type, course.Id);

            if (NotificationsFired.Contains(lookupTuple) == false)
            {
                CreateNotification(
                $"{type.Name} {EnumUtilities.GetDescription<NotificationType>(notificationType)} Today!",
                $"{type.Name} {course.CourseCode} - {course.Title} {EnumUtilities.GetDescription<NotificationType>(notificationType).ToLower()} today."
            );

                NotificationsFired.Add(lookupTuple);
            }
        }

        private void CreateAssessmentNotification(object item, NotificationType notificationType)
        {
            var assessment = (Assessment)item;
            var type = assessment.GetType();
            var lookupTuple = new Tuple<Type, int>(type, assessment.Id);

            if (NotificationsFired.Contains(lookupTuple) == false)
            {
                CreateNotification(
                $"{type.Name} {EnumUtilities.GetDescription<NotificationType>(notificationType)} today!",
                $"{assessment.AssessmentType} {type.Name} {assessment.Title} {EnumUtilities.GetDescription<NotificationType>(notificationType).ToLower()} today."
            );

                NotificationsFired.Add(lookupTuple);
            }
        }

        private async Task<List<T>> GetEventsByStartDate<T>(DateTime date) where T : class, new()
        {
            Type type = typeof(T);
            string querybase = $"SELECT * FROM {type.Name}s" ;
            List <T> matches = await DataConnection.QueryAsync<T>($"{querybase} WHERE StartDate = ? AND NotificationsEnabled = ?", date, true);
            return matches;
        }
        private async Task<List<T>> GetEventsByEndDate<T>(DateTime date) where T : class, new()
        {
            Type type = typeof(T);
            string querybase = $"SELECT * FROM {type.Name}s";
            List<T> matches = await DataConnection.QueryAsync<T>($"{querybase} WHERE EndDate = ? AND NotificationsEnabled = ?", date, true);
            return matches;
        }
        
        private void CreateNotification(string title, string message)
        {
            NotificationNumber++;
            NotificationManager.ScheduleNotification(title, message);
        }
               
        private async void AddTerm_Button_Clicked(object sender, EventArgs e)
        {
            var page = Factory.GetEntryView<Term>(UserOperation.Add, DataConnection);
            await Navigation.PushAsync(page, true);
        }
                
        private void TermsListView_Refreshing(object sender, EventArgs e)
        {
            
        }
               
        private async void TermsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var term = (Term)(e.Item);
            var page = Factory.GetDetailView<Term>(DataConnection, term);
            await Navigation.PushAsync(page, true);

        }
    }
}