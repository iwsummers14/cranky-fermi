﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.Enum;
using TermTracker.Factory;
using TermTracker.Interfaces;
using TermTracker.Models;
using TermTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [Description("ViewDetailTerm")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermDetailPage : ContentPage
    {
        private ViewFactory Factory { get => new ViewFactory(); }

        private SQLiteAsyncConnection DataConnection { get; set; }

        private ObservableCollection<Course> CoursesList;

        private Term CurrentTerm { get; set; }

        public TermDetailPage(ref SQLiteAsyncConnection dConn, Term termToLoad )
        {
            InitializeComponent();
            CurrentTerm = termToLoad;
            DataConnection = dConn;
        }

        protected override async void OnAppearing()
        {
            var courses = await DataConnection.QueryAsync<Course>("SELECT * FROM Courses WHERE TermId = ?", CurrentTerm.Id);
            CoursesList = new ObservableCollection<Course>(courses);
            CoursesListView.ItemsSource = CoursesList;
            TitleText.Text = $"Courses for {CurrentTerm.Title}";
        }
               
        private async void EditTerm_Clicked(object sender, EventArgs e)
        {
            var view = Factory.GetEntryView<Term>(UserOperation.Edit, DataConnection, CurrentTerm);
            await Navigation.PushAsync(view);
        }

        private async void DeleteTerm_Clicked(object sender, EventArgs e)
        {
            var confirmation = await DisplayAlert($"Delete Term", $"Are you sure you want to delete term \n'{CurrentTerm.Title}'?", "Yes", "No");

            if (confirmation == true)
            {
                await DataConnection.DeleteAsync<Term>(CurrentTerm.Id);
                await Navigation.PopAsync();
            }
        }

        private async void AddCourse_Clicked(object sender, EventArgs e)
        {
            var view = Factory.GetEntryView<Course>(UserOperation.Add, DataConnection, null, CurrentTerm.Id);
            await Navigation.PushAsync(view);
        }

        private async void CoursesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var course = (Course)(e.Item);
            var view = Factory.GetDetailView<Course>(DataConnection, course);
            await Navigation.PushAsync(view);
        }
    }
}