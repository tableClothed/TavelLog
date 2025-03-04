﻿using databaseApp.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace databaseApp
{
    public partial class App : Application
    {
        static NoteDatabase database;
        // LocalNotificationsImplementation.NotificationIconId = Resource.Drawable.icon;

        public static NoteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteDatabase(Path.Combine(Environment.
                        GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.db3"));
                }
            return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new NotesPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
