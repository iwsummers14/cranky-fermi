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
            catch 
            {       
                
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
            await DataConnection.CreateTableAsync<Assessment>();
            await DataConnection.CreateTableAsync<Instructor>();
            await DataConnection.CreateTableAsync<Course>();

        }

        private async void HydrateTables()
        {

            var seedStartDate = new DateTime(2020, 10, 01);
            var status = System.Enum.GetName(typeof(TermStatus), TermStatus.NotStarted);
            int index;
            List<Term> termRecords = new List<Term>();
            
            for (index = 1 ;  index <= 6; index++)
            {
                var demoTerm = new Term()
                {
                    Title = $"Term {index}",
                    StartDate = seedStartDate,
                    EndDate = seedStartDate.AddMonths(6),
                    Status = status
                };

                termRecords.Add(demoTerm);
               
                seedStartDate = seedStartDate.AddMonths(6).AddDays(1);
            }

            await DataConnection.InsertAllAsync(termRecords);
            
        }
    }
}
