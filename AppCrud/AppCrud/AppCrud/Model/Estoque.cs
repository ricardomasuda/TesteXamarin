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



        public async Task<List<Estoque>> BuscarEstoque(Page Page)
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
    }

  

}
