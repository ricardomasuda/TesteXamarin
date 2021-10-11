using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static AppCrud.Model.Request;

namespace AppCrud.Model
{
    public class Estoque
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }



        public async void BuscarEstoque(Page Page)
        {
            var _request = new SimpleRequest("Estoque");
            var response = await HttpRequest<SimpleRequest>.GetAsync(_request, Page);
        }
    }

  

}
