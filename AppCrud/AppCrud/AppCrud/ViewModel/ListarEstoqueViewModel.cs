using AppCrud.Banco;
using AppCrud.Model;
using AppCrud.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AppCrud.ViewModel
{
    class ListarEstoqueViewModel
    {

        public ObservableCollection<Estoque> ListaEstoque { get; set; }
        public Command Cadastrar { get; set; }
        public Command AtualizarEstoqueCmd { get; set; }
        public ListarEstoqueViewModel()
        {

       
            CarregarEstoque();
            Cadastrar = new Command(CadastrarEstoque);
            AtualizarEstoqueCmd = new Command(AtualizarEstoque);
        }
        public void CadastrarEstoque()
        {
            App.NavPage.PushAsync(new DetalheEstoque());
        }

        public async void CarregarEstoque() 
        {
            EstoqueDB Estoquebanco = new EstoqueDB();
            ListaEstoque = new ObservableCollection<Estoque>(await Estoquebanco.PesquisarAsync());
        }
        public void AtualizarEstoque(object sender)
        {
            Estoque estoque = (Estoque)sender;
            App.NavPage.PushAsync(new DetalheEstoque(estoque));
        }

       

    }
}
