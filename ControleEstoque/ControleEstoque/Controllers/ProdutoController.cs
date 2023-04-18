using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleEstoque.Context;
using ControleEstoque.Models;
using ControleEstoque.Models.ViewModels;
using System.Diagnostics;

namespace ControleEstoque.Controllers;

public class ProdutoController : Controller
{
    private readonly AppDbContext _context;

    public ProdutoController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Produto
    public async Task<IActionResult> Index()
    {
        var appDbContext = _context.Produto.Include(p => p.Categoria).Include(p => p.Lote);
        return View(await appDbContext.ToListAsync());
    }

    // GET: Produto/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Produto == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        var produto = await _context.Produto
            .Include(p => p.Categoria)
            .Include(p => p.Lote)
            .FirstOrDefaultAsync(m => m.ProdutoId == id);
        if (produto == null)
        {
            return NotFound();
        }

        return View(produto);
    }

    // GET: Produto/Create
    public IActionResult Create()
    {
        ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaNome");
        ViewData["LoteId"] = new SelectList(_context.Set<Lote>(), "LoteId", "Referencia");
        return View();
    }

    // POST: Produto/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ProdutoId,Nome,DescricaoDetalhada,ImagemUrl,IsProdutoPreferido,EstoqueMinimo,EstoqueMaximo,Estoque,CategoriaId,LoteId")] Produto produto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaNome", produto.CategoriaId);
        ViewData["LoteId"] = new SelectList(_context.Set<Lote>(), "LoteId", "Referencia", produto.LoteId);
        return View(produto);
    }

    // GET: Produto/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Produto == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        var produto = await _context.Produto.FindAsync(id);
        if (produto == null)
        {
            return RedirectToAction(nameof(Error), new { message = "O produto não foo encontrado" });
        }
        ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaNome", produto.CategoriaId);
        ViewData["LoteId"] = new SelectList(_context.Set<Lote>(), "LoteId", "Referencia", produto.LoteId);
        return View(produto);
    }

    // POST: Produto/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,Nome,DescricaoDetalhada,ImagemUrl,IsProdutoPreferido,EstoqueMinimo,EstoqueMaximo,Estoque,CategoriaId,LoteId")] Produto produto)
    {
        if (id != produto.ProdutoId)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(produto.ProdutoId))
                {
                    return RedirectToAction(nameof(Error), new { message = "O produto selecionado não foi encontrado" });
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaNome", produto.CategoriaId);
        ViewData["LoteId"] = new SelectList(_context.Set<Lote>(), "LoteId", "Referencia", produto.LoteId);
        return View(produto);
    }

    // GET: Produto/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Produto == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        var produto = await _context.Produto
            .Include(p => p.Categoria)
            .Include(p => p.Lote)
            .FirstOrDefaultAsync(m => m.ProdutoId == id);
        if (produto == null)
        {
            return RedirectToAction(nameof(Error), new { message = "O produto selecionado não foi encontrado" });
        }

        return View(produto);
    }

    // POST: Produto/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Produto == null)
        {
            return RedirectToAction(nameof(Error), new { message = "O produto seleionado não possui nenhum valor" });
        }
        var produto = await _context.Produto.FindAsync(id);
        if (produto != null)
        {
            _context.Produto.Remove(produto);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProdutoExists(int id)
    {
      return _context.Produto.Any(e => e.ProdutoId == id);
    }

    public IActionResult Error(string message)
    {
        var viewModel = new ErrorViewModel
        {
            Message = message,
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };
        return View(viewModel);
    }
}
