using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TermTracker.Configuration;
using TermTracker.Interfaces;
using TermTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [Description("AddOrEditTerm")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrEditTermPage : ContentPage
    {
        private SQLiteAsyncConnection DataConnection { get; set; }

        private Term CurrentTerm { get; set; }

        public AddOrEditTermPage()
        {
            InitializeComponent();
        }

        public AddOrEditTermPage(ref SQLiteAsyncConnection dConn, Term termToLoad)
        {
            InitializeComponent();
            InitializeViewEdit(dConn, termToLoad);
                        
        }

        private async void InitializeViewEdit( SQLiteAsyncConnection dConn, Term termToLoad) 
        {
            DataConnection = dConn;
            CurrentTerm = await DataConnection.GetAsync<Term>(termToLoad.Id);
        }

    }
}