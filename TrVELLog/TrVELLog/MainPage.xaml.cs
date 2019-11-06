using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrVELLog.ViewModels;
using Xamarin.Forms;

namespace TrVELLog
{
    public partial class MainPage : ContentPage
    {
        MainVM viewModel;
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            viewModel = new MainVM();
            BindingContext = viewModel;

            iconImage.Source = ImageSource.FromResource("TrVELLog.Assets.Images.plane.jpg", assembly);
        }

        private void RegisterUserButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
