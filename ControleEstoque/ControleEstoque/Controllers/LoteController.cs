using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleEstoque.Context;
using ControleEstoque.Models;
using ControleEstoque.Models.ViewModels;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace ControleEstoque.Controllers;

[Authorize]
public class LoteController : Controller
{
    private readonly AppDbContext _context;

    public LoteController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var appDbContext = _context.Lote.Include(l => l.Fornecedor);
        return View(await appDbContext.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Lote == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        var lote = await _context.Lote
            .Include(l => l.Fornecedor)
            .FirstOrDefaultAsync(m => m.LoteId == id);
        if (lote == null)
        {
            return RedirectToAction(nameof(Error), new { message = "O lote não foi encontrado" });
        }

        return View(lote);
    }

    public IActionResult Create()
    {
        ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "Nome");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("LoteId,Referencia,FornecedorId")] Lote lote)
    {
        if (ModelState.IsValid)
        {
            _context.Add(lote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "Nome", lote.FornecedorId);
        return View(lote);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Lote == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        var lote = await _context.Lote.FindAsync(id);
        if (lote == null)
        {
            return RedirectToAction(nameof(Error), new { message = "O lote não foi encontrado" });
        }
        ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "Nome", lote.FornecedorId);
        return View(lote);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("LoteId,Referencia,FornecedorId")] Lote lote)
    {
        if (id != lote.LoteId)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(lote);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoteExists(lote.LoteId))
                {
                    return RedirectToAction(nameof(Error), new { message = "O lote selecionado não foi encontrado" });
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "Nome", lote.FornecedorId);
        return View(lote);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Lote == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        var lote = await _context.Lote
            .Include(l => l.Fornecedor)
            .FirstOrDefaultAsync(m => m.LoteId == id);
        if (lote == null)
        {
            return RedirectToAction(nameof(Error), new { message = "O lote não foi encontrado" });
        }

        return View(lote);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Lote == null)
        {
            return RedirectToAction(nameof(Error), new { message = "O lote selecionado não possui nenhum valor" });
        }
        var lote = await _context.Lote.FindAsync(id);
        if (lote != null)
        {
            _context.Lote.Remove(lote);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LoteExists(int id)
    {
        return _context.Lote.Any(e => e.LoteId == id);
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
