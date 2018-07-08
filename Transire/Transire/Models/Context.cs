using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Transire.Models
{
    public class Context : DbContext
    {
        public Context(string connString = "TransireDb")
        : base(connString)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().MapToStoredProcedures();
            modelBuilder.Entity<Produto>().MapToStoredProcedures();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Produto> Produtos { get; set; }
        
    }
}