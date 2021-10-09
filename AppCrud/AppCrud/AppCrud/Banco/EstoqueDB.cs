using AppCrud.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCrud.Banco
{
    public class EstoqueDB
    {
        private BancoContext Banco { get; set; }

        public EstoqueDB()
        {
            Banco = new BancoContext();
        }
        public async Task<List<Estoque>> PesquisarAsync()
        {
            return await Banco.Estoque.ToListAsync();
        }
        public async Task<bool> CadastrarAsync(Estoque estoque)
        {
            Banco.Estoque.Add(estoque);
            int linhas = await Banco.SaveChangesAsync();
            return (linhas > 0) ? true : false;
        }

        public async Task<bool> AtualizarAsync(Estoque tarefa)
        {
            Banco.Estoque.Update(tarefa);
            int linhas = await Banco.SaveChangesAsync();
            return (linhas > 0) ? true : false;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            Estoque tarefa = await ConsultarAsync(id);
            Banco.Estoque.Remove(tarefa);
            int linhas = await Banco.SaveChangesAsync();
            return (linhas > 0) ? true : false;
        }

        public async Task<Estoque> ConsultarAsync(int id)
        {
            return await Banco.Estoque.FindAsync(id);
        }

    }
}
