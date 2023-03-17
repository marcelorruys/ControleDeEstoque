using ControleEstoque.Context;
using ControleEstoque.Models;
using ControleEstoque.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Produto> Produtos => _context.Produto.Include(c => c.Categoria);

    public IEnumerable<Produto> ProdutosPreferidos => _context.Produto.Where(p => p.IsProdutoPreferido).Include(c => c.Categoria);

    public Produto GetProdutoById(int produtoId)
    {
        return _context.Produto.FirstOrDefault(p => p.ProdutoId == produtoId);
    }
}
