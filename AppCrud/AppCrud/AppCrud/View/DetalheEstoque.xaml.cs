using AppCrud.Model;
using AppCrud.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCrud.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheEstoque : ContentPage
    {
        private Estoque Estoque { get; set; }
        public DetalheEstoque(Estoque estoque=null)
        {
            Estoque = estoque;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new DetalheEstoqueViewModel(this, Estoque);
        }
    }
}