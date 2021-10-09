using AppCrud.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCrud
{
    public partial class App : Application
    {
        public static NavigationPage NavPage { get; set; }
        public App()
        {
            InitializeComponent();

      
            NavPage = new NavigationPage(new ListarEstoque());
            MainPage = NavPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
