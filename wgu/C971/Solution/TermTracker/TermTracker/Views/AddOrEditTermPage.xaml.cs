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
using TermTracker.Enum;
using TermTracker.Utilities;
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

        private List<string> StatusValues { get; set; }
        
        public AddOrEditTermPage()
        {
            InitializeComponent();
        }

        public AddOrEditTermPage(ref SQLiteAsyncConnection dConn, Nullable<int> parentId = null)
        {
            InitializeComponent();
            InitializeViewAdd(dConn);
                        
        }

        public AddOrEditTermPage(ref SQLiteAsyncConnection dConn, Term termToLoad)
        {
            InitializeComponent();
            InitializeViewEdit(dConn, termToLoad);

        }

        private void InitializeViewAdd(SQLiteAsyncConnection dConn)
        {
            DataConnection = dConn;
            CurrentTerm = new Term();
            TitleText.Text = "Add Term";
            
        }

        private async void InitializeViewEdit( SQLiteAsyncConnection dConn, Term termToLoad) 
        {
            DataConnection = dConn;
            CurrentTerm = await DataConnection.GetAsync<Term>(termToLoad.Id);
            TitleText.Text = "Edit Term";

            ent_TermTitle.Text = CurrentTerm.Title;
            dp_TermStart.Date = CurrentTerm.StartDate;
            dp_TermEnd.Date = CurrentTerm.EndDate;

        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            InsertOrReplace(CloseForm);
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void InsertOrReplace(Action callback)
        {
            CurrentTerm.Title = ent_TermTitle.Text;
            CurrentTerm.StartDate = dp_TermStart.Date;
            CurrentTerm.EndDate = dp_TermEnd.Date;

            await DataConnection.InsertOrReplaceAsync(CurrentTerm, typeof(Term));
            
            callback();
        }

        private async void CloseForm()
        {
            await Navigation.PopAsync();
        }

    }
}