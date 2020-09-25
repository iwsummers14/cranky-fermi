using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageHeaderView : ContentView
    {
        public PageHeaderView()
        {
            InitializeComponent();
        }
    }
}