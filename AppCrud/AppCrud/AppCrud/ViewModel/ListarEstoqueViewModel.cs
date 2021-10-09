using AppCrud.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppCrud.ViewModel
{
    class ListarEstoqueViewModel
    {
        public Command Cadastrar { get; set; }
        public ListarEstoqueViewModel()
        {
           
            Cadastrar = new Command(CadastrarEstoque);
        }
        public void CadastrarEstoque()
        {
            App.NavPage.PushAsync(new DetalheEstoque());
        }
    }
}
