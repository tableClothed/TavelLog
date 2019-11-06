using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrVELLog.Models
{
    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public async Task<bool>  Login(string email, string password)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(email);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if (isEmailEmpty || isPasswordEmpty)
            {
                return false;
            }
            else
            {
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
            await App.sql_conn.InsertAsync(user);
        }
    }
}
