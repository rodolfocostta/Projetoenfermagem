using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EnfermariaSenac.Data;
using EnfermariaSenac.Models;

namespace EnfermariaSenac.Controllers
{
    public class EnfermagemsController : Controller
    {
        private readonly DBContext _context;

        public EnfermagemsController(DBContext context)
        {
            _context = context;
        }

        // GET: Enfermagems
        public async Task<IActionResult> Index()
        {
              return _context.Enfermagem != null ? 
                          View(await _context.Enfermagem.ToListAsync()) :
                          Problem("Entity set 'DBContext.Enfermagem'  is null.");
        }

        // GET: Enfermagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enfermagem == null)
            {
                return NotFound();
            }

            var enfermagem = await _context.Enfermagem
                .FirstOrDefaultAsync(m => m.ID_Enfermagem == id);
            if (enfermagem == null)
            {
                return NotFound();
            }

            return View(enfermagem);
        }

        // GET: Enfermagems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enfermagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Enfermagem,Nome_Enfermagem,Coren")] Enfermagem enfermagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enfermagem);
        }

        // GET: Enfermagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enfermagem == null)
            {
                return NotFound();
            }

            var enfermagem = await _context.Enfermagem.FindAsync(id);
            if (enfermagem == null)
            {
                return NotFound();
            }
            return View(enfermagem);
        }

        // POST: Enfermagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Enfermagem,Nome_Enfermagem,Coren")] Enfermagem enfermagem)
        {
            if (id != enfermagem.ID_Enfermagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfermagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfermagemExists(enfermagem.ID_Enfermagem))
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
            return View(enfermagem);
        }

        // GET: Enfermagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enfermagem == null)
            {
                return NotFound();
            }

            var enfermagem = await _context.Enfermagem
                .FirstOrDefaultAsync(m => m.ID_Enfermagem == id);
            if (enfermagem == null)
            {
                return NotFound();
            }

            return View(enfermagem);
        }

        // POST: Enfermagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enfermagem == null)
            {
                return Problem("Entity set 'DBContext.Enfermagem'  is null.");
            }
            var enfermagem = await _context.Enfermagem.FindAsync(id);
            if (enfermagem != null)
            {
                _context.Enfermagem.Remove(enfermagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermagemExists(int id)
        {
          return (_context.Enfermagem?.Any(e => e.ID_Enfermagem == id)).GetValueOrDefault();
        }
    }
}
