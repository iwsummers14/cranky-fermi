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
    /// <summary>
    /// The main page of the application.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private INotificationManager NotificationManager;

        private int NotificationNumber = 0;

        List<Tuple<Type, int>> NotificationsFired = new List<Tuple<Type, int>>();

        private Startup AppStart;

        private SQLiteAsyncConnection DataConnection;

        private ObservableCollection<Term> TermsList;

        private BackgroundWorker NotificationWorker { get; set; }

        private ViewFactory Factory { get => new ViewFactory(); }

        public string ViewTitle = "Term Tracker";

        // constructor
        public MainPage()
        {
            
            InitializeComponent();

            // initialize notification manager and create a background worker to handle notifications
            NotificationManager = DependencyService.Get<INotificationManager>();
            NotificationManager.Initialize();

            NotificationWorker = new BackgroundWorker();
            NotificationWorker.DoWork += ProcessNotifications;
            

            // create a startup object and assign an event handler to it, get the data connection back from it
            AppStart = new Startup();
            AppStart.StartupComplete += AppStart_StartupComplete;
            DataConnection = AppStart.DataConnection;
            TitleText.Text = ViewTitle;
            
        }

        // event handler method for when startup is complete
        private async void AppStart_StartupComplete(object sender, StartupCompleteEventArgs e)
        {
            var terms = await DataConnection.Table<Term>().ToListAsync();
            TermsList = new ObservableCollection<Term>(terms);
            TermsListView.ItemsSource = TermsList;
        }

        // override of the OnAppearing method to tell the background worker to run
        protected override async void OnAppearing() 
        {
            if (NotificationWorker.IsBusy == false)
            {
                NotificationWorker.RunWorkerAsync();
            }
        }

        // 'work' method for the background worker to create notifications
        private void ProcessNotifications(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);

            DateTime today = DateTime.Today;

            CreateAndLogNotifications<Course>(today, NotificationType.Starts);
            CreateAndLogNotifications<Course>(today, NotificationType.IsDue);
            CreateAndLogNotifications<Assessment>(today, NotificationType.Starts);
            CreateAndLogNotifications<Assessment>(today, NotificationType.IsDue);

        }

        // method to get courses and assessments that the app should notify the user about; can be 'starts today' or 'is due today' 
        private void CreateAndLogNotifications<T>(DateTime date, NotificationType notificationType) where T : class, new()
        {
            Type type = typeof(T);
            Task<List<T>> events = null;

            switch (notificationType)
            {
                case NotificationType.Starts:
                    events = GetEventsByStartDate<T>(date);
                    break;
                case NotificationType.IsDue:
                    events = GetEventsByEndDate<T>(date);
                    break;
            }

            foreach (T item in events.Result)
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

        // method to create a notification for a course, and record it as a tuple so it is not fired again
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

        // method to create a notification for an assessment, and record it as a tuple so it is not fired again
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

        // method to get a list of items T by their start date
        private async Task<List<T>> GetEventsByStartDate<T>(DateTime date) where T : class, new()
        {
            Type type = typeof(T);
            string querybase = $"SELECT * FROM {type.Name}s" ;
            List <T> matches = await DataConnection.QueryAsync<T>($"{querybase} WHERE StartDate = ? AND NotificationsEnabled = ?", date, true);
            return matches;
        }

        // method to get a list of items T by their end date
        private async Task<List<T>> GetEventsByEndDate<T>(DateTime date) where T : class, new()
        {
            Type type = typeof(T);
            string querybase = $"SELECT * FROM {type.Name}s";
            List<T> matches = await DataConnection.QueryAsync<T>($"{querybase} WHERE EndDate = ? AND NotificationsEnabled = ?", date, true);
            return matches;
        }

        // method to create a user notification and schedule it
        private void CreateNotification(string title, string message)
        {
            NotificationNumber++;
            NotificationManager.ScheduleNotification(title, message);
        }
               
        // event handler method for the add term button
        private async void AddTerm_Button_Clicked(object sender, EventArgs e)
        {
            var page = Factory.GetEntryView<Term>(UserOperation.Add, DataConnection);
            await Navigation.PushAsync(page, true);
        }
        
        // event handler method for tapping a term item in the terms itemlist
        private async void TermsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var term = (Term)(e.Item);
            var page = Factory.GetDetailView<Term>(DataConnection, term);
            await Navigation.PushAsync(page, true);

        }
    }
}