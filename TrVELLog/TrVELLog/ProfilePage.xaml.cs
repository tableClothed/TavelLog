using SQLite;
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
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var postTable = conn.Table<Post>().ToList();

                var categories = postTable.OrderBy(p => p.CategoryId).Where(p => p.CategoryName != null).Distinct().ToList();

                postCountLabel.Text = postTable.Count.ToString();
            }
        }
    }
}