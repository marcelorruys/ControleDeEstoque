using Microsoft.EntityFrameworkCore;
using ControleEstoque.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ControleEstoque.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<ControleEstoque.Models.Lote> Lote { get; set; }


    }
}
