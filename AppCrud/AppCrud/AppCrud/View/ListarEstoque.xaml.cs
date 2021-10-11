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
    public partial class ListarEstoque : ContentPage
    {
        public ListarEstoque()
        {
            InitializeComponent();
            Estoque Estoque = new Estoque();
            Estoque.BuscarEstoque(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ListarEstoqueViewModel();
        }


    }
}