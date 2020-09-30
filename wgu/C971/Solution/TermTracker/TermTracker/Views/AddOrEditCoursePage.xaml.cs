using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.Interfaces;
using TermTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [Description("AddOrEditCourse")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrEditCoursePage : ContentPage
    {
        private SQLiteAsyncConnection DataConnection { get; set; }

        private Course CurrentCourse { get; set; }

        public AddOrEditCoursePage()
        {
            InitializeComponent();
        }

        public AddOrEditCoursePage(ref SQLiteAsyncConnection dConn, int parentId)
        {
            InitializeComponent();
            InitializeViewAdd(dConn, parentId);

        }

        public AddOrEditCoursePage(ref SQLiteAsyncConnection dConn, Course courseToLoad)
        {
            InitializeComponent();
            InitializeViewEdit(dConn, courseToLoad);

        }

        private async void InitializeViewEdit(SQLiteAsyncConnection dConn, Course courseToLoad)
        {
            DataConnection = dConn;
            CurrentCourse = await DataConnection.GetAsync<Course>(courseToLoad.Id);
        }

        private async void InitializeViewAdd(SQLiteAsyncConnection dConn, int parentId)
        {
            DataConnection = dConn;
        }
    }
}