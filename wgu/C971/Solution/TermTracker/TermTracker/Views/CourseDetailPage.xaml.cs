using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [Description("ViewDetailCourse")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseDetailPage : ContentPage
    {

        private string ViewTitle = "Course Detail";

        public CourseDetailPage()
        {
            InitializeComponent();
            TitleText.Text = ViewTitle;
        }

        private async void ViewCellAssessment_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssessmentDetailPage());
        }

        private void EditCourse_Clicked(object sender, EventArgs e)
        {

        }

        private void DeleteCourse_Clicked(object sender, EventArgs e)
        {

        }
    }
}