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
    public class ItemComprasController : Controller
    {
        private readonly Context _context;

        public ItemComprasController(Context context)
        {
            _context = context;
        }

        // GET: ItemCompras
        public async Task<IActionResult> Index()
        {
            var context = _context.ItemCompras.Include(i => i.Compras).Include(i => i.Produtos);
            return View(await context.ToListAsync());
        }

        // GET: ItemCompras/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ItemCompras == null)
            {
                return NotFound();
            }

            var itemCompra = await _context.ItemCompras
                .Include(i => i.Compras)
                .Include(i => i.Produtos)
                .FirstOrDefaultAsync(m => m.ItemCompraId == id);
            if (itemCompra == null)
            {
                return NotFound();
            }

            return View(itemCompra);
        }

        // GET: ItemCompras/Create
        public IActionResult Create()
        {
            ViewData["CompraId"] = new SelectList(_context.Compras, "CompraId", "CompraId");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId");
            return View();
        }

        // POST: ItemCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemCompraId,CompraId,ProdutoId")] ItemCompra itemCompra)
        {
            if (ModelState.IsValid)
            {
                itemCompra.ItemCompraId = Guid.NewGuid();
                _context.Add(itemCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompraId"] = new SelectList(_context.Compras, "CompraId", "CompraId", itemCompra.CompraId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", itemCompra.ProdutoId);
            return View(itemCompra);
        }

        // GET: ItemCompras/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ItemCompras == null)
            {
                return NotFound();
            }

            var itemCompra = await _context.ItemCompras.FindAsync(id);
            if (itemCompra == null)
            {
                return NotFound();
            }
            ViewData["CompraId"] = new SelectList(_context.Compras, "CompraId", "CompraId", itemCompra.CompraId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", itemCompra.ProdutoId);
            return View(itemCompra);
        }

        // POST: ItemCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ItemCompraId,CompraId,ProdutoId")] ItemCompra itemCompra)
        {
            if (id != itemCompra.ItemCompraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemCompraExists(itemCompra.ItemCompraId))
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
            ViewData["CompraId"] = new SelectList(_context.Compras, "CompraId", "CompraId", itemCompra.CompraId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", itemCompra.ProdutoId);
            return View(itemCompra);
        }

        // GET: ItemCompras/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ItemCompras == null)
            {
                return NotFound();
            }

            var itemCompra = await _context.ItemCompras
                .Include(i => i.Compras)
                .Include(i => i.Produtos)
                .FirstOrDefaultAsync(m => m.ItemCompraId == id);
            if (itemCompra == null)
            {
                return NotFound();
            }

            return View(itemCompra);
        }

        // POST: ItemCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ItemCompras == null)
            {
                return Problem("Entity set 'Context.ItemCompras'  is null.");
            }
            var itemCompra = await _context.ItemCompras.FindAsync(id);
            if (itemCompra != null)
            {
                _context.ItemCompras.Remove(itemCompra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemCompraExists(Guid id)
        {
          return (_context.ItemCompras?.Any(e => e.ItemCompraId == id)).GetValueOrDefault();
        }
    }
}
