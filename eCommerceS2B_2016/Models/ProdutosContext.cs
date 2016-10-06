using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace eCommerceS2B_2016.Models
{
    public class ProdutosContext : DbContext
    {
        public ProdutosContext() : base() { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Vendas> Vendas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }
    }
}