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
            return await Banco.Estoque.Where(u => u.Status != 3).ToListAsync();
        }
        public async Task<List<Estoque>> PesquisarTudoAsync()
        {
            return await Banco.Estoque.ToListAsync();
        }
        public async Task<bool> CadastrarAsync(Estoque estoque, int status=1)
        {
            estoque.Status = status;
            Banco.Estoque.Add(estoque);
            int linhas = await Banco.SaveChangesAsync();
            return (linhas > 0) ? true : false;
       
        }

        public async Task<bool> AtualizarAsync(Estoque estoque)
        {
            estoque.Status = 2;
            Banco.Estoque.Update(estoque);
            int linhas = await Banco.SaveChangesAsync();
            return (linhas > 0) ? true : false;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            Estoque estoque = await ConsultarAsync(id);
            estoque.Status = 3;
            Banco.Estoque.Update(estoque);
            //Banco.Estoque.Remove(tarefa);
            int linhas = await Banco.SaveChangesAsync();
            return (linhas > 0) ? true : false;
        }
        public async Task<bool> ExcluirTotalAsync(int id)
        {
            Estoque estoque = await ConsultarAsync(id);
            Banco.Estoque.Remove(estoque);
            int linhas = await Banco.SaveChangesAsync();
            return (linhas > 0) ? true : false;
        }

        public async Task<bool> AlteraState(Estoque estoque)
        {
            estoque.Status = 0;
            Banco.Estoque.Update(estoque);
            int linhas = await Banco.SaveChangesAsync();
            return (linhas > 0) ? true : false;
        }

        public async Task<Estoque> ConsultarAsync(int id)
        {
            return await Banco.Estoque.FindAsync(id);
        }

    }
}
