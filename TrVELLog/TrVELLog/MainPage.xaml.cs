using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrVELLog
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            iconImage.Source = ImageSource.FromResource("TrVELLog.Assets.Images.plane.jpg", assembly);
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool a = string.IsNullOrEmpty(password.Text);
            bool b = string.IsNullOrEmpty(login.Text);

            if (!a && !b)
            {
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}
