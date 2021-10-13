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
        public ObservableCollection<Estoque> ListaEstoque { get { return _ListaEstoque; } set { _ListaEstoque = value; OnPropertyChanged("ListaEstoque"); } }
        public ObservableCollection<Estoque> _ListaEstoque { get; set; }
        public Command CadastrarCmd { get; set; }
        public Command SincronizarCmd { get; set; }
        public Command AtualizarEstoqueCmd { get; set; }
        public ListarEstoqueViewModel()
        {

       
            CarregarEstoque();
            SincronizarCmd = new Command(Sincronizar);
            CadastrarCmd = new Command(CadastrarEstoque);
            AtualizarEstoqueCmd = new Command(AtualizarEstoque);
        }
        public void CadastrarEstoque()
        {
            App.NavPage.PushAsync(new DetalheEstoque());
        }
        public void Sincronizar()
        {
            Estoque estoque = new Estoque();
            estoque.Sincronizar();
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }

    }
}
