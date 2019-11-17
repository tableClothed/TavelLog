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
	public partial class FixPage : ContentPage
	{
		public FixPage()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}