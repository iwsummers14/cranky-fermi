using System.ComponentModel;
using Xamarin.Forms;
using TermTracker.ViewModels;

namespace TermTracker.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}