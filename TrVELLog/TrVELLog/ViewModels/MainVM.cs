using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TrVELLog.Models;
using TrVELLog.ViewModels.Commands;

namespace TrVELLog.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        public User user { get; set; }
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }
        public LoginCommand LoginCommand { get; set; }
        public string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };

                OnPropertyChanged("Email");
            }
        }
        public string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }
        }

        public MainVM()
        {
            user = new User();
            LoginCommand = new LoginCommand(this);
        }

        public async void Login()
        {
            bool canLogin = await User.Login(User.Email, User.Password);

            if (canLogin)
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            else
                await App.Current.MainPage.DisplayAlert("Error", "Try again", "Ok");
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
