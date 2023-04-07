using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleEstoque.Context;
using ControleEstoque.Models;

namespace ControleEstoque.Controllers
{
    public class LoteController : Controller
    {
        private readonly AppDbContext _context;

        public LoteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Lote
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Lote.Include(l => l.Fornecedor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Lote/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lote == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote
                .Include(l => l.Fornecedor)
                .FirstOrDefaultAsync(m => m.LoteId == id);
            if (lote == null)
            {
                return NotFound();
            }

            return View(lote);
        }

        // GET: Lote/Create
        public IActionResult Create()
        {
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "Cep");
            return View();
        }

        // POST: Lote/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "Cep", lote.FornecedorId);
            return View(lote);
        }

        // GET: Lote/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lote == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote.FindAsync(id);
            if (lote == null)
            {
                return NotFound();
            }
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "Cep", lote.FornecedorId);
            return View(lote);
        }

        // POST: Lote/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoteId,Referencia,FornecedorId")] Lote lote)
        {
            if (id != lote.LoteId)
            {
                return NotFound();
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
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "Cep", lote.FornecedorId);
            return View(lote);
        }

        // GET: Lote/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lote == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote
                .Include(l => l.Fornecedor)
                .FirstOrDefaultAsync(m => m.LoteId == id);
            if (lote == null)
            {
                return NotFound();
            }

            return View(lote);
        }

        // POST: Lote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lote == null)
            {
                return Problem("Entity set 'AppDbContext.Lote'  is null.");
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
    }
}
