using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TermTracker.Interfaces;
using TermTracker.Models;
using Xamarin.Forms;

namespace TermTracker.Configuration
{
    public class Startup
    {
        public SQLiteAsyncConnection DataConnection { get; private set; }

        public Startup()
        {
            DataConnection = DependencyService.Get<IDataConnection>().GetDataConnection();
            CheckDatabase();
        }

        private async void CheckDatabase()
        {
            try
            {
                var terms = await DataConnection.Table<Term>().ToListAsync();
            }
            catch (SQLiteException sqEx)
            {
                Console.WriteLine($"Error: {sqEx.Message}");
                CreateTables();
                HydrateTables();
            }
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
            //await
        }
    }
}
