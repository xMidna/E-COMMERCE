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
    public class CarrelloesController : Controller
    {
        private readonly ECOMMERCEContext _context;

        public CarrelloesController(ECOMMERCEContext context)
        {
            _context = context;
        }

        // GET: Carrelloes
        public async Task<IActionResult> Index()
        {
              return _context.Carrellos != null ? 
                          View(await _context.Carrellos.ToListAsync()) :
                          Problem("Entity set 'ECOMMERCEContext.Carrellos'  is null.");
        }

        // GET: Carrelloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carrellos == null)
            {
                return NotFound();
            }

            var carrello = await _context.Carrellos
                .FirstOrDefaultAsync(m => m.IdCarrello == id);
            if (carrello == null)
            {
                return NotFound();
            }

            return View(carrello);
        }

        // GET: Carrelloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carrelloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCarrello,Total")] Carrello carrello)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrello);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrello);
        }

        // GET: Carrelloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carrellos == null)
            {
                return NotFound();
            }

            var carrello = await _context.Carrellos.FindAsync(id);
            if (carrello == null)
            {
                return NotFound();
            }
            return View(carrello);
        }

        // POST: Carrelloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCarrello,Total")] Carrello carrello)
        {
            if (id != carrello.IdCarrello)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrello);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrelloExists(carrello.IdCarrello))
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
            return View(carrello);
        }

        // GET: Carrelloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carrellos == null)
            {
                return NotFound();
            }

            var carrello = await _context.Carrellos
                .FirstOrDefaultAsync(m => m.IdCarrello == id);
            if (carrello == null)
            {
                return NotFound();
            }

            return View(carrello);
        }

        // POST: Carrelloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carrellos == null)
            {
                return Problem("Entity set 'ECOMMERCEContext.Carrellos'  is null.");
            }
            var carrello = await _context.Carrellos.FindAsync(id);
            if (carrello != null)
            {
                _context.Carrellos.Remove(carrello);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrelloExists(int id)
        {
          return (_context.Carrellos?.Any(e => e.IdCarrello == id)).GetValueOrDefault();
        }
    }
}
