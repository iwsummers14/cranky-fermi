using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TermTracker.Interfaces;
using TermTracker.Models;
using Xamarin.Forms;
using TermTracker.Enum;
using System.Runtime.CompilerServices;

namespace TermTracker.Configuration
{
    public class Startup
    {
        public SQLiteAsyncConnection DataConnection { get; private set; }

        public Startup()
        {
            DataConnection = DependencyService.Get<IDataConnection>(DependencyFetchTarget.NewInstance).GetDataConnection();
            CheckDatabase();
        }

        private async void CheckDatabase()
        {
            try
            {
                var terms = await DataConnection.Table<Term>().ToListAsync();
                if (terms == null)
                {
                    InitializeDatabase();
                }
                
            }
            catch (SQLiteException sqEx)
            {       
                Console.WriteLine($"Error: {sqEx.Message}");
                InitializeDatabase();
            }

        }

        private void InitializeDatabase()
        {
            CreateTables();
            HydrateTables();
        }

        private async void CreateTables()
        {
            await DataConnection.CreateTableAsync<Term>();
            await DataConnection.CreateTableAsync<Course>();
            await DataConnection.CreateTableAsync<Assessment>();
            await DataConnection.CreateTableAsync<Instructor>();

        }

        private async void HydrateTables()
        {
            var demoTerm = new Term()
            {
                Title = "Term 1",
                StartDate = new DateTime(2020, 08, 01),
                EndDate = new DateTime(2020, 08, 01),
                Status = System.Enum.GetName(typeof(TermStatus), TermStatus.NotStarted),
            };

            await DataConnection.InsertAsync(demoTerm);

        }
    }
}
