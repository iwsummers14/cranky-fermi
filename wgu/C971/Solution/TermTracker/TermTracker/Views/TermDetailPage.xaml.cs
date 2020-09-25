using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermDetailPage : ContentPage
    {
        private string ViewTitle = "Term Details";

        public TermDetailPage()
        {
            InitializeComponent();
            TitleText.Text = ViewTitle;
        }

        private async void ViewCellCourse_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CourseDetailPage());
        }

        private void EditTerm_Clicked(object sender, EventArgs e)
        {

        }

        private void DeleteTerm_Clicked(object sender, EventArgs e)
        {

        }

        private void AddCourse_Clicked(object sender, EventArgs e)
        {

        }

        
    }
}