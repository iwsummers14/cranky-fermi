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
            Logger = DependencyService.Get<ILogger>(DependencyFetchTarget.NewInstance);
            CheckDatabase();
        }

        private async void CheckDatabase()
        {

            try
            {
                
                var terms = await DataConnection.Table<Term>().ToListAsync();
                if (terms == null || terms.Count == 0)
                {
                    InitializeDatabase();
                }
                
            }
            catch (SQLite.SQLiteException ex)
            {
                Logger.WriteLogEntry(ex.Message);
                InitializeDatabase();
            }

        }

        private async void InitializeDatabase()
        {
            var tablesReady = await CreateTables();

            if (tablesReady)
            {
               var recordsReady = await HydrateTables();
                
                if (recordsReady == false)
                {
                    throw new Exception("Population of database records has failed.");
                }
            }
            else
            {
                throw new Exception("Table creation has failed");
            }
            

        }

        private async Task<bool> CreateTables()
        {
            var success = false;

            try
            {
                await DataConnection.CreateTableAsync<Term>();
                await DataConnection.CreateTableAsync<Assessment>();
                await DataConnection.CreateTableAsync<Instructor>();
                await DataConnection.CreateTableAsync<Course>();

                success = true;
            }

            catch (Exception ex)
            {
                Logger.WriteLogEntry(ex.Message);
                return success;
            }

            return success;

        }

        private async Task<bool> HydrateTables()
        {
            bool success = false;
            var seedStartDate = new DateTime(2020, 10, 01);
            var status = EnumUtilities.GetDescription<TermStatus>(TermStatus.NotStarted);
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

            try
            {
                var records = await DataConnection.InsertAllAsync(termRecords);
                if (records == 6)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogEntry(ex.Message);
                success = false;
            }
            return success;
        }
    }
}
