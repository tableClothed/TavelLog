﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrVELLog.Models;
using TrVELLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrVELLog
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{
        HomeVM viewModel;
		public HistoryPage ()
		{
			InitializeComponent ();

            viewModel = new HomeVM();
            BindingContext = viewModel;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var posts = await Post.Read();

            postListView.ItemsSource = posts;
                
        }

        private void PostListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = postListView.SelectedItem as Post;

            if (selectedPost != null)
                Navigation.PushAsync(new PostDetailPage(selectedPost));
        }
    }
}