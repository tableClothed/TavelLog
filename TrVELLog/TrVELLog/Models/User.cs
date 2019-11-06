using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace TrVELLog.Models
{
    public class User : INotifyPropertyChanged
    {
        public string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async static Task<bool> Login(string email, string password)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(email);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if (isEmailEmpty || isPasswordEmpty)
            {
                return false;
            }
            else
            {
                await App.sql_conn.CreateTableAsync<User>();
                var user = await App.sql_conn.Table<User>().FirstOrDefaultAsync(u => u.Email == email);

                if (user != null )
                {
                    App.user = user;
                    if (user.Password == password)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }

        }

        public static async void Register(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                throw new Exception("Nieprawidlowe haslo lub email");

            await App.sql_conn.CreateTableAsync<User>();
            await App.sql_conn.InsertAsync(user);
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
