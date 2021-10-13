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
            public int Id { get; set; }
            public string Nome { get; set; }
            public int Quantidade { get; set; }
            public int Status { get; set; }
            public CadastrarEstoqueRequest(Estoque _estoque)
            {
                Action = "Estoque";
                Id = _estoque.Id;
                Nome = _estoque.Nome;
                Quantidade = _estoque.Quantidade;
                Status = _estoque.Status;
            }
        }
    }
}
