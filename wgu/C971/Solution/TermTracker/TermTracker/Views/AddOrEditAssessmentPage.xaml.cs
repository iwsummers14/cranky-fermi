using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [Description("AddOrEditAssessment")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrEditAssessmentPage : ContentPage, ITermTrackerView
    {
        public AddOrEditAssessmentPage()
        {
            InitializeComponent();
        }
    }
}