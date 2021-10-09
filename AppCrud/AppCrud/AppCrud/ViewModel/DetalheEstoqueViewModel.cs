using AppCrud.Banco;
using AppCrud.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppCrud.ViewModel
{
    public class DetalheEstoqueViewModel
    {
        public bool ViewBotao { get; set; }
        public Estoque Estoque { get; set; } = new Estoque();
        public Command DeleterCmd { get; set; }
        public Command SalvarCmd { get; set; }
        Page Page;
        public DetalheEstoqueViewModel(Page page,Estoque _estoque)
        {
            Page = page;
            if (_estoque !=null)
                Estoque = _estoque;
            ViewBotao = _estoque != null;
            SalvarCmd = new Command(Salvar);
            DeleterCmd = new Command(DeletetarEstoque);
        }
        public  void Salvar()
        {
            if (Estoque == null)
                Cadastrar();
            else
                Atualizar();
            App.NavPage.PopAsync();
        }
        public async void Cadastrar()
        {
            EstoqueDB Estoquebanco = new EstoqueDB();
            if (Validar())
            {
                if (await Estoquebanco.CadastrarAsync(Estoque))
                    await Page.DisplayAlert("Cadastrado", "Item Cadastrado com sucesso", "ok");
                else
                    await Page.DisplayAlert("Não cadastrado", "Não foi possivel cadastrar", "ok");
            }
        }

        public async void Atualizar()
        {
            EstoqueDB Estoquebanco = new EstoqueDB();
            if (Validar())
            {
                if (await Estoquebanco.AtualizarAsync(Estoque))
                    await Page.DisplayAlert("Atualizado", "Item atualizado com sucesso", "ok");
                else
                    await Page.DisplayAlert("Não atualizado", "Não foi possivel cadastrar", "ok");
            }
        }
        public async void DeletetarEstoque()
        {
            if(await Page.DisplayAlert("Deseja deletar item?", "Item não podera ser recupardo", "Sim", "Não"))
            {
                EstoqueDB Estoquebanco = new EstoqueDB();
                if (await Estoquebanco.ExcluirAsync(Estoque.Id))
                {
                    await Page.DisplayAlert("Item Deletado", "Item foi deletadod o estoque", "ok");
                   await  App.NavPage.PopAsync();
                }
                   
            }
        }
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Estoque.Nome))
            {
                Page.DisplayAlert("Nome não pode ser vazio","insira o nome","ok");
                return false;
            }
            if (Estoque.Quantidade == 0)
            {
                Page.DisplayAlert("Quantidade não pode ser 0", "insira um valor", "ok");
                return false;
            }
            return true;
        }

    }
}
