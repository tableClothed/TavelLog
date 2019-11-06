using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrVELLog.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrVELLog
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        User user;
        public RegisterPage()
        {
            InitializeComponent();

            user = new User();
            containerStackLayout.BindingContext = user;
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if (passwordEntry.Text == confirmPasswordEntry.Text)
            {
                User.Register(user);
                //var ok = await User.Login(user.Email, user.Password);

                //if (ok)
                //{
                //    App.user = user;

                //    await Navigation.PushAsync(new HomePage());
                //}
            } else
            {
                await DisplayAlert("Error", "Passwords dont match", "Ok");
            }
        }
    }
}