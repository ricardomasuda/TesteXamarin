using AppCrud.View;
using System;
using AppCrud.Model;
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
        }

        protected  override void OnStart()
        {
            Estoque Estoque = new Estoque();
            Estoque.LimparBase();
            NavPage = new NavigationPage(new ListarEstoque());
            MainPage = NavPage;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
