﻿using databaseApp.Models;
using Plugin.LocalNotifications;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace databaseApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            note.Date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }

        private void AlertButton_Clicked(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Show("title", "body");
        }
    }
}