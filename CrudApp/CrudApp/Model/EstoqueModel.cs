using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApp.Model
{
    public class EstoqueModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }



        public List<EstoqueModel> ListarEstoque()
        {
            List<EstoqueModel> ListaEstoque = new List<EstoqueModel>() { };
            ListaEstoque.Add(new EstoqueModel() { Id = 1, Nome = "Camisa", Quantidade = 10 });
            ListaEstoque.Add(new EstoqueModel() { Id = 2, Nome = "Mouse", Quantidade = 18 });
            ListaEstoque.Add(new EstoqueModel() { Id = 3, Nome = "Notebbok", Quantidade = 7 });
            return ListaEstoque;
        }
        public EstoqueModel BuscarEstoque(int Id)
        {
            EstoqueModel Estoque = new EstoqueModel();

            return Estoque;
        }
        public int SetEstoque(EstoqueModel Estoque)
        {
            return 0;
        }
        public bool UpdateEstoque(EstoqueModel Estoque)
        {
            return true;
        }
        public bool DeletarEstoque(int EstoqueId)
        {
            return true;
        }


    }
}
