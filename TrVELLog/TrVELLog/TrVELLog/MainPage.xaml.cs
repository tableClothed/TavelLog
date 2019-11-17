using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrVELLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;


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



        }
    }
}
