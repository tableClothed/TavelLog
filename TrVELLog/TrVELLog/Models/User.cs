using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrVELLog.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Login(string email, string password)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                bool isEmailEmpty = string.IsNullOrEmpty(email);
                bool isPasswordEmpty = string.IsNullOrEmpty(password);

                if (isEmailEmpty || isPasswordEmpty)
                {
                    return false;
                }
                else
                {
                    conn.CreateTable<User>();
                    var user = conn.Table<User>().FirstOrDefault(u => u.Email == email);

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
        }

        public static void Register(User user)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<User>();
                conn.Insert(user);
            }
        }
    }
}
