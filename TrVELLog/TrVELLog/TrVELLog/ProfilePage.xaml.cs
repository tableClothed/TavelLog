using ImageCircle.Forms.Plugin.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrVELLog.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ImageCircle.Forms.Plugin;

namespace TrVELLog
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();

            CreatePicture();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


        }

        private void CreatePicture()
        {
            new CircleImage
            {
                BorderColor = Color.White,
                BorderThickness = 3,
                HeightRequest = 150,
                WidthRequest = 150,
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center,
                Source = UriImageSource.FromUri(new Uri("http://upload.wikimedia.org/wikipedia/commons/5/55/Tamarin_portrait.JPG"))
            };
        }
    }
}