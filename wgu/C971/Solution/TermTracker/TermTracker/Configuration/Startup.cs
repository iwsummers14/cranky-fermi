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

namespace TermTracker.Configuration
{
    public class Startup
    {
        public SQLiteAsyncConnection DataConnection { get; private set; }
        
        public ILogger Logger { get; private set; }

        public Startup()
        {
            DataConnection = DependencyService.Get<IDataConnection>(DependencyFetchTarget.NewInstance).GetDataConnection();
            PrepareDatabase();

            Logger = DependencyService.Get<ILogger>(DependencyFetchTarget.NewInstance);
        }

        private void PrepareDatabase()
        {

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

            callback();
        }

        private void InitializeDatabase()
        {
            // create tables
            CreateTables(HydrateTables);

        }

        private async void CreateTables(Action callback)
        {
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

            callback();
        }

        private async void HydrateTables()
        {
            var seedStartDate = new DateTime(2020, 10, 01);
            int index;
            List<Term> termRecords = new List<Term>();
            List<Course> courseRecords = new List<Course>();
            Instructor instructor = new Instructor()
            {
                Name = "Ian Summers",
                EmailAddress = "isumme1@wgu.edu",
                PhoneNumber = "314-575-6545"
            };

            
            // add 3 demo terms
            for (index = 1 ;  index <= 3; index++)
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

            seedStartDate = DateTime.Now;

            // add 4 demo courses
            for (index = 1; index <= 4; index++)
            {
                var demoCourse = new Course()
                {
                    TermId = 1,
                    Title = $"Software Concepts, Level {index}",
                    CourseCode = $"C10{index}",
                    InstructorId = 1,
                    StartDate = seedStartDate,
                    EndDate = seedStartDate.AddDays(30),
                    Status = EnumUtilities.GetDescription<CourseStatus>(CourseStatus.NotStarted)
                };

                courseRecords.Add(demoCourse);

                seedStartDate = seedStartDate.AddDays(31);
            }

            try
            {
                await DataConnection.InsertAsync(instructor);
                await DataConnection.InsertAllAsync(termRecords);
                await DataConnection.InsertAllAsync(courseRecords);
                
            }
            catch (Exception ex)
            {
                Logger.WriteLogEntry(ex.Message);
            }

        }
    }
}
