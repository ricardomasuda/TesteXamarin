using AppCrud.Banco;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static AppCrud.Model.Request;

namespace AppCrud.Model
{
    public class Estoque
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public int Status { get; set; }

        public async Task<List<Estoque>> BuscarEstoque(Page Page = null)
        {
            var _request = new SimpleRequest("Estoque");
            var response = await HttpRequest<SimpleRequest>.GetAsync(_request, Page);
            if (response != null)
            {
                if (response.Status == "Sucesso")
                {
                    try
                    {
                        JArray jObject = response.Conteudo as JArray;
                        var ListaBalanco = jObject.ToObject<List<Estoque>>();

                        return ListaBalanco;
                    }
                    catch (Exception e)
                    {
                        //await Page.DisplayAlert("Erro", e.Message + "\n\n" + e.StackTrace, "Ok");
                    }
                }
            }
            return null;
        }

        public async Task<bool> LimparBase()
        {
            EstoqueDB estoque = new EstoqueDB();
            foreach (var estoqueAux in await estoque.PesquisarTudoAsync())
            {
                await estoque.ExcluirTotalAsync(estoqueAux.Id);
            }

            foreach (var estoqueAdd in await BuscarEstoque())
            {
                await estoque.CadastrarAsync(estoqueAdd,0);
            }
            return true;
        }

        public async Task<bool> Sincronizar()
        {
            EstoqueDB estoque = new EstoqueDB();
            var ListaPesquisa = await estoque.PesquisarTudoAsync();
            foreach (Estoque _estoque in ListaPesquisa)
            {
             
                var _request = new CadastrarEstoqueRequest(_estoque);
                var response = await HttpRequest<CadastrarEstoqueRequest>.PostAsync(_request);
                if (response != null)
                {
                    if (response.Status != "Sucesso")
                    {
                        return false;
                    }
                }
            }
            await LimparBase();
            return true;
        }


    }



}
