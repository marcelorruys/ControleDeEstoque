using Microsoft.EntityFrameworkCore;
using ControleEstoque.Models;

namespace ControleEstoque.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Categoria> Categoria { get; set; }


    }
}
