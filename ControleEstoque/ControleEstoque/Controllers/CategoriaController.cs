using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleEstoque.Context;
using ControleEstoque.Models;
using ControleEstoque.Models.ViewModels;
using System.Diagnostics;

namespace ControleEstoque.Controllers;

public class CategoriaController : Controller
{
    private readonly AppDbContext _context;

    public CategoriaController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Categoria
    public async Task<IActionResult> Index()
    {
          return View(await _context.Categoria.ToListAsync());
    }

    // GET: Categoria/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Categoria == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        var categoria = await _context.Categoria
            .FirstOrDefaultAsync(m => m.CategoriaId == id);
        if (categoria == null)
        {
            return RedirectToAction(nameof(Error), new { message = "A categoria não foi encontrada" });
        }

        return View(categoria);
    }

    // GET: Categoria/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Categoria/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CategoriaId,CategoriaNome,Descricao")] Categoria categoria)
    {
        if (ModelState.IsValid)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(categoria);
    }

    // GET: Categoria/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Categoria == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        var categoria = await _context.Categoria.FindAsync(id);
        if (categoria == null)
        {
            return RedirectToAction(nameof(Error), new { message = "A categoria não foi encontrada" });
        }
        return View(categoria);
    }

    // POST: Categoria/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("CategoriaId,CategoriaNome,Descricao")] Categoria categoria)
    {
        if (id != categoria.CategoriaId)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(categoria);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(categoria.CategoriaId))
                {
                    return RedirectToAction(nameof(Error), new { message = "A categoria indicada não foi encontrada" });

                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(categoria);
    }

    // GET: Categoria/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Categoria == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        var categoria = await _context.Categoria
            .FirstOrDefaultAsync(m => m.CategoriaId == id);
        if (categoria == null)
        {
            return RedirectToAction(nameof(Error), new { message = "A Categoria não foi encontrada" });

        }

        return View(categoria);
    }

    // POST: Categoria/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Categoria == null)
        {
            return RedirectToAction(nameof(Error), new { message = "A categoria selecionada não foi encontrada" });
        }
        var categoria = await _context.Categoria.FindAsync(id);
        if (categoria != null)
        {
            _context.Categoria.Remove(categoria);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CategoriaExists(int id)
    {
      return _context.Categoria.Any(e => e.CategoriaId == id);
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
