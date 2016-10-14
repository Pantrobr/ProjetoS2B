using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjetoS2B.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }
    }
}