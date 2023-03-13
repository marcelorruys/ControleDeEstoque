using ControleEstoque.Context;
using ControleEstoque.Models;
using ControleEstoque.Repositories.Interfaces;

namespace ControleEstoque.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categoria;
    }
}
