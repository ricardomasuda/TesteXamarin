using CrudApp.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApp.Controllers
{
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        [Route("/api/[controller]")]
        [HttpGet]
        public Response GetListEstoque()
        {
            EstoqueModel Estoque = new EstoqueModel();
            List<EstoqueModel> ListaEstoque = new List<EstoqueModel>();
            Response result = new Response();
            ListaEstoque = Estoque.ListarEstoque();
            if (Estoque != null)
            {
                result.Status = "Sucesso";
                result.Conteudo =ListaEstoque.Cast<object>().ToList();
                return result;
            }
            result.Status = "Erro";
            return result;
        }


        [Route("/api/[controller]/{IdEstoque}")]
        [HttpGet]
        public Response GetEstoque(int IdEstoque)
        {
            EstoqueModel Estoque = new EstoqueModel();
            Response result = new Response();
            Estoque = Estoque.BuscarEstoque(IdEstoque);

            if (Estoque != null)
            {
                result.Status = "Sucesso";
                result.Conteudo.Add(Estoque);
                return result;
            }
            result.Status = "Erro";
            return result;
        }

        [Route("/api/[controller]")]
        [HttpPost]
        public Response CadastrarEstoque(EstoqueModel estoque)
        {
            EstoqueModel Estoque = new EstoqueModel();
            Response result = new Response();
            var retorno = Estoque.SetEstoque(estoque);
            if (retorno > 0)
            {
                result.Status = "Sucesso";
                result.Conteudo.Add(retorno);
            }
            else
                result.Status = "Erro";
            return result;
        }

        [HttpPut]
        [Route("/api/[controller]")]
        public Response AlterarEstoque(EstoqueModel estoque)
        {
            EstoqueModel Estoque = new EstoqueModel();
            Response result = new Response();
            if (Estoque.UpdateEstoque(estoque))
                result.Status = "Sucesso";
            else
                result.Status = "Erro";
            return result;
        }

        [HttpDelete]
        [Route("/api/[controller]/{IdEstoque}")]
        public Response ExcluirEstoque(int IdEstoque)
        {
            EstoqueModel Estoque = new EstoqueModel();
            Response result = new Response();

            if (Estoque.DeletarEstoque(IdEstoque))
                result.Status = "Sucesso";
            else
                result.Status = "Erro";
            return result;
        }
    }
}
