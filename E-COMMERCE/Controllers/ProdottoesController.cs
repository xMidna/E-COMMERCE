using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_COMMERCE.Models;

namespace E_COMMERCE.Controllers
{
    public class ProdottoesController : Controller
    {
        private readonly ECOMMERCEContext _context;

        public ProdottoesController(ECOMMERCEContext context)
        {
            _context = context;
        }

        // GET: Prodottoes
        public async Task<IActionResult> Index()
        {
              return _context.Prodottos != null ? 
                          View(await _context.Prodottos.ToListAsync()) :
                          Problem("Entity set 'ECOMMERCEContext.Prodottos'  is null.");
        }

        // GET: Prodottoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prodottos == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodottos
                .FirstOrDefaultAsync(m => m.IdProdotto == id);
            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // GET: Prodottoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prodottoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProdotto,Nome,Prezzo")] Prodotto prodotto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodotto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prodotto);
        }

        // GET: Prodottoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prodottos == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodottos.FindAsync(id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return View(prodotto);
        }

        // POST: Prodottoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProdotto,Nome,Prezzo")] Prodotto prodotto)
        {
            if (id != prodotto.IdProdotto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodotto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdottoExists(prodotto.IdProdotto))
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
            return View(prodotto);
        }

        // GET: Prodottoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prodottos == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodottos
                .FirstOrDefaultAsync(m => m.IdProdotto == id);
            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // POST: Prodottoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prodottos == null)
            {
                return Problem("Entity set 'ECOMMERCEContext.Prodottos'  is null.");
            }
            var prodotto = await _context.Prodottos.FindAsync(id);
            if (prodotto != null)
            {
                _context.Prodottos.Remove(prodotto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdottoExists(int id)
        {
          return (_context.Prodottos?.Any(e => e.IdProdotto == id)).GetValueOrDefault();
        }
    }
}
