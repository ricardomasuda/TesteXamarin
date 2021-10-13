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
        public int Status { get; set; }


        public List<EstoqueModel> ListaEstoque = new List<EstoqueModel>() { };
        public List<EstoqueModel> ListarEstoque()
        {

            ListaEstoque.Add(new EstoqueModel() { Id = 1, Nome = "Camisa", Quantidade = 10, Status = 0 });
            ListaEstoque.Add(new EstoqueModel() { Id = 2, Nome = "Mouse", Quantidade = 18, Status = 0 });
            ListaEstoque.Add(new EstoqueModel() { Id = 3, Nome = "Notebbok", Quantidade = 7, Status = 0 });
            return ListaEstoque;
        }
        public EstoqueModel BuscarEstoque(int Id)
        {
            EstoqueModel Estoque = new EstoqueModel();

            return Estoque;
        }
        public List<EstoqueModel> SetEstoque(EstoqueModel Estoque)
        {
            switch (Estoque.Status)
            {
                case 1:
                    Estoque.Status = 0;
                    ListaEstoque.Add(Estoque);break;
                case 2:
                    Estoque.Status = 0;
                    ListaEstoque.Remove(Estoque);
                    ListaEstoque.Add(Estoque); break;
                case 3:
                    ListaEstoque.Remove(Estoque);break;
            }
            return ListaEstoque;
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
