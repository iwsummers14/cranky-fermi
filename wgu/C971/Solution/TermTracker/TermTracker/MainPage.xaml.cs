using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.Configuration;
using TermTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TermTracker.ViewModels;
using TermTracker.Views;

namespace TermTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection DataConnection;

        private ObservableCollection<Term> TermsList;

        public string ViewTitle = "Term Tracker";

        public MainPage()
        {
            InitializeComponent();
            DataConnection = new Startup().DataConnection;
            TitleText.Text = ViewTitle;
        }

        protected override async void OnAppearing() 
        {
            var terms = await DataConnection.Table<Term>().ToListAsync();
            TermsList = new ObservableCollection<Term>(terms);
            TermsListView.ItemsSource = TermsList;
        
        }
               
        private void AddTerm_Button_Clicked(object sender, EventArgs e)
        {

        }
                
        private void TermsListView_Refreshing(object sender, EventArgs e)
        {
            
        }

        private async void ViewCellTerm_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermDetailPage(), true);
            
        }
    }
}