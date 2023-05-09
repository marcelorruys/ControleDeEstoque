using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleEstoque.Context;
using ControleEstoque.Models;
using ControleEstoque.Models.ViewModels;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace ControleEstoque.Controllers;

[Authorize]
public class FornecedorController : Controller
{
    private readonly AppDbContext _context;

    public FornecedorController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Fornecedor
    public async Task<IActionResult> Index()
    {
          return View(await _context.Fornecedor.ToListAsync());
    }

    // GET: Fornecedor/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Fornecedor == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        var fornecedor = await _context.Fornecedor
            .FirstOrDefaultAsync(m => m.FornecedorId == id);
        if (fornecedor == null)
        {
            return RedirectToAction(nameof(Error), new { message = "O fornecedor não foi encontrado" });
        }

        return View(fornecedor);
    }

    // GET: Fornecedor/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Fornecedor/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FornecedorId,Nome,RazaoSocial,Cnpj,Telefone,Email,Endereco1,Endereco2,Cep,Estado,Cidade,DescricaoDetalhada")] Fornecedor fornecedor)
    {
        if (ModelState.IsValid)
        {
            _context.Add(fornecedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(fornecedor);
    }

    // GET: Fornecedor/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Fornecedor == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        var fornecedor = await _context.Fornecedor.FindAsync(id);
        if (fornecedor == null)
        {
            return RedirectToAction(nameof(Error), new { message = "O fornecedor não foi encontrado" });
        }
        return View(fornecedor);
    }

    // POST: Fornecedor/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("FornecedorId,Nome,RazaoSocial,Cnpj,Telefone,Email,Endereco1,Endereco2,Cep,Estado,Cidade,DescricaoDetalhada")] Fornecedor fornecedor)
    {
        if (id != fornecedor.FornecedorId)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(fornecedor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(fornecedor.FornecedorId))
                {
                    return RedirectToAction(nameof(Error), new { message = "O fornecedor não foi encontrado" });
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(fornecedor);
    }

    // GET: Fornecedor/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Fornecedor == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Código inválido" });
        }

        var fornecedor = await _context.Fornecedor
            .FirstOrDefaultAsync(m => m.FornecedorId == id);
        if (fornecedor == null)
        {
            return RedirectToAction(nameof(Error), new { message = "O fornecedor não foi encontrado" });
        }

        return View(fornecedor);
    }

    // POST: Fornecedor/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Fornecedor == null)
        {
            return RedirectToAction(nameof(Error), new { message = "O fornecedor selecionado não possui nenhum valor" });
        }
        var fornecedor = await _context.Fornecedor.FindAsync(id);
        if (fornecedor != null)
        {
            _context.Fornecedor.Remove(fornecedor);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FornecedorExists(int id)
    {
      return _context.Fornecedor.Any(e => e.FornecedorId == id);
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
