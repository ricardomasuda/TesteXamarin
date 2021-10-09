using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using AppCrud.Model;

namespace AppCrud.Banco
{
    class BancoContext : DbContext
    {
        public DbSet<Estoque> Estoque { get; set; }
        public BancoContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={Constantes.CaminhoDoBanco}");
        }
    }
}
