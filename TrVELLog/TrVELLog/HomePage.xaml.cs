using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrVELLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrVELLog
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : TabbedPage
	{
        HomeVM viewModel;
		public HomePage ()
		{
			InitializeComponent ();

            viewModel = new HomeVM();
            BindingContext = viewModel;
		}
    }
}