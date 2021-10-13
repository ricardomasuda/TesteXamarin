using System;
using System.Collections.Generic;
using System.Text;

namespace AppCrud.Model
{
    class Request
    {
        public interface IRequest
        {
            string Action { get; set; }
        }
        public class SimpleRequest : IRequest
        {
            public string Action { get; set; }
            public SimpleRequest(string action)
            {
                Action = action;
            }
        }
        public class CadastrarEstoqueRequest : IRequest
        {
            public string Action { get; set; }
            public Estoque Estoque { get; set; }
            public CadastrarEstoqueRequest(Estoque _estoque)
            {
                Action = "/api/Estoque";
                Estoque = _estoque;
            }
        }
    }
}
