using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TermTracker.Interfaces;
using TermTracker.Models;
using Xamarin.Forms;
using TermTracker.Enum;
using System.Runtime.CompilerServices;
using System.IO;
using TermTracker.Utilities;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using TermTracker.Events;

namespace TermTracker.Configuration
{
    /// <summary>
    /// Class to invoke app startup tasks. Since this is a 'demo' application the database is re-initialized on every run.
    /// In a production scenario the database would be checked and then initialized if not present (i.e. first launch).
    /// 
    /// In the context of this project this class injects the test data into the database at app start.
    /// An event handler is used to indicate when startup is complete.
    /// </summary>
    public class Startup
    {

        public event EventHandler<StartupCompleteEventArgs> StartupComplete;

        public SQLiteAsyncConnection DataConnection { get; private set; }
        
        public ILogger Logger { get; private set; }

        public Startup()
        {
            // Data connection and logger classes for the specific platform are initialized
            DataConnection = DependencyService.Get<IDataConnection>(DependencyFetchTarget.NewInstance).GetDataConnection();
            Logger = DependencyService.Get<ILogger>(DependencyFetchTarget.NewInstance);
            
            PrepareDatabase();
        }

        private void PrepareDatabase()
        {
            // Clear data and re-initialize the database
            try
            {
                CleanDatabase(InitializeDatabase);
                                                
            }
            catch (SQLite.SQLiteException ex)
            {
                Logger.WriteLogEntry(ex.Message);
            }

        }

        private async void CleanDatabase(Action callback)
        {
            // Drop all tables
            await DataConnection.DropTableAsync<Assessment>();
            await DataConnection.DropTableAsync<Course>();
            await DataConnection.DropTableAsync<Instructor>();
            await DataConnection.DropTableAsync<Term>();

            // Execute the callback function 
            callback();
        }

        private void InitializeDatabase()
        {
            // create tables and add records
            CreateTables(HydrateTables);

        }

        private async void CreateTables(Action callback)
        {
            
            // Create tables in order of dependencies
            try
            {
                
                await DataConnection.CreateTableAsync<Term>();
                await DataConnection.CreateTableAsync<Assessment>();
                await DataConnection.CreateTableAsync<Instructor>();
                await DataConnection.CreateTableAsync<Course>();
            }

            catch (Exception ex)
            {
                Logger.WriteLogEntry(ex.Message);
                
            }

            // Execute callback function
            callback();
        }

        private async void HydrateTables()
        {
            // set up seed values for various demo records and lists for holding multiple records
            var seedStartDate = DateTime.Today;
            int index;
            List<Term> termRecords = new List<Term>();
            List<Course> courseRecords = new List<Course>();
            List<Assessment> assessmentRecords = new List<Assessment>();

            // add author as instructor for test data 
            Instructor instructor = new Instructor()
            {
                Name = "Ian Summers",
                EmailAddress = "isumme1@wgu.edu",
                PhoneNumber = "(314) 575-6545"
            };
                        
            // add 2 demo terms, increasing dates 
            for (index = 1 ;  index <= 2; index++)
            {
                var demoTerm = new Term()
                {
                    Title = $"Term {index}",
                    StartDate = seedStartDate,
                    EndDate = seedStartDate.AddMonths(6),
                    Status = EnumUtilities.GetDescription<TermStatus>(TermStatus.NotStarted)
                };

                termRecords.Add(demoTerm);
               
                seedStartDate = seedStartDate.AddMonths(6).AddDays(1);
            }

            // reset the seed date value
            seedStartDate = DateTime.Today;

            // add 2 demo courses, increasing dates 
            for (index = 1; index <= 2; index++)
            {
                var demoCourse = new Course()
                {
                    TermId = 1,
                    Title = $"Software Concepts, Level {index}",
                    CourseCode = $"C10{index}",
                    InstructorId = 1,
                    StartDate = seedStartDate,
                    EndDate = seedStartDate.AddDays(30),
                    Status = EnumUtilities.GetDescription<CourseStatus>(CourseStatus.NotStarted),
                    NotificationsEnabled = true,
                    Notes = "This course is very difficult! Be sure to contact the course mentors, they are very helpful."
                };

                courseRecords.Add(demoCourse);

                seedStartDate = seedStartDate.AddDays(31);
            }

            // add an objective and performance assessment to the first course
            assessmentRecords.Add(
                new Assessment()
                {
                    Title = "Exam",
                    AssessmentType = EnumUtilities.GetDescription<AssessmentType>(AssessmentType.Objective),
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today,
                    Status = EnumUtilities.GetDescription<AssessmentStatus>(AssessmentStatus.NotAttempted),
                    NotificationsEnabled = true,
                    CourseId = 1

                });
            assessmentRecords.Add(
                new Assessment() 
                {
                    Title = "Project",
                    AssessmentType = EnumUtilities.GetDescription<AssessmentType>(AssessmentType.Performance),
                    StartDate = DateTime.Today.AddDays(7),
                    EndDate = DateTime.Today.AddDays(30),
                    Status = EnumUtilities.GetDescription<AssessmentStatus>(AssessmentStatus.NotAttempted),
                    NotificationsEnabled = true,
                    CourseId = 1
                });

            // insert the records into the database
            try
            {
                await DataConnection.InsertAsync(instructor);
                await DataConnection.InsertAllAsync(termRecords);
                await DataConnection.InsertAllAsync(courseRecords);
                await DataConnection.InsertAllAsync(assessmentRecords);
                
            }
            catch (Exception ex)
            {
                Logger.WriteLogEntry(ex.Message);
            }
                        
            // trigger the startup complete event
            StartupCompleteEventArgs startupComplete = new StartupCompleteEventArgs() { TablesHydrated = true };
            OnComplete(startupComplete);

        }

        // method to invoke the event
        protected void OnComplete(StartupCompleteEventArgs e)
        {
            StartupComplete?.Invoke(this, e);
        }
    }
}
