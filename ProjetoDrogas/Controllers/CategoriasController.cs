using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoDrogas.Data;
using ProjetoDrogas.Models;

namespace ProjetoDrogas.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly Context _context;

        public CategoriasController(Context context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
              return _context.CategoriaDeProdutos != null ? 
                          View(await _context.CategoriaDeProdutos.ToListAsync()) :
                          Problem("Entity set 'Context.CategoriaDeProdutos'  is null.");
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.CategoriaDeProdutos == null)
            {
                return NotFound();
            }

            var categoria = await _context.CategoriaDeProdutos
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaId,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.CategoriaId = Guid.NewGuid();
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.CategoriaDeProdutos == null)
            {
                return NotFound();
            }

            var categoria = await _context.CategoriaDeProdutos.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CategoriaId,Nome")] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return NotFound();
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
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.CategoriaDeProdutos == null)
            {
                return NotFound();
            }

            var categoria = await _context.CategoriaDeProdutos
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.CategoriaDeProdutos == null)
            {
                return Problem("Entity set 'Context.CategoriaDeProdutos'  is null.");
            }
            var categoria = await _context.CategoriaDeProdutos.FindAsync(id);
            if (categoria != null)
            {
                _context.CategoriaDeProdutos.Remove(categoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(Guid id)
        {
          return (_context.CategoriaDeProdutos?.Any(e => e.CategoriaId == id)).GetValueOrDefault();
        }
    }
}
