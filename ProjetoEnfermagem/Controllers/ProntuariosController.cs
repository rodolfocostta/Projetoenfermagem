using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EnfermariaSenac.Data;
using EnfermariaSenac.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EnfermariaSenac.Controllers
{
    public class ProntuariosController : Controller
    {
        private readonly DBContext _context;

        public ProntuariosController(DBContext context)
        {
            _context = context;
        }

       // GET: Prontuarios
        public async Task<IActionResult> Index()
        {
            return _context.Prontuario != null ?
                        View(await _context.Prontuario.ToListAsync()) :
                        Problem("Entity set 'DBContext.Prontuario'  is null.");




        }




        // GET: Prontuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prontuario == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuario
                .FirstOrDefaultAsync(m => m.ID_Prontuario == id);
            if (prontuario == null)
            {
                return NotFound();
            }

            return View(prontuario);
        }

        // GET: Prontuarios/Create
        public IActionResult Create()
        {
            ProntuarioModel model = new ProntuarioModel();
            model.listadePaciente = _context.Paciente.ToList();
            model.listadeEnfermagem = _context.Enfermagem.ToList();
            return View(model);
        }

        // POST: Prontuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Prontuario,ID_Paciente,ID_Enfermagem,Relatorioatendimento,Nome_Paciente,Nome_Enfermagem,Data,Horario")] Prontuario prontuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prontuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prontuario);
        }

        // GET: Prontuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prontuario == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuario.FindAsync(id);
            if (prontuario == null)
            {
                return NotFound();
            }
            return View(prontuario);
        }

        // POST: Prontuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Prontuario,ID_Paciente,ID_Enfermagem,Relatorioatendimento,Nome_Paciente,Nome_Enfermagem,Data,Horario")] Prontuario prontuario)
        {
            if (id != prontuario.ID_Prontuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prontuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProntuarioExists(prontuario.ID_Prontuario))
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
            return View(prontuario);
        }

        // GET: Prontuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prontuario == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuario
                .FirstOrDefaultAsync(m => m.ID_Prontuario == id);
            if (prontuario == null)
            {
                return NotFound();
            }

            return View(prontuario);
        }

        // POST: Prontuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prontuario == null)
            {
                return Problem("Entity set 'DBContext.Prontuario'  is null.");
            }
            var prontuario = await _context.Prontuario.FindAsync(id);
            if (prontuario != null)
            {
                _context.Prontuario.Remove(prontuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProntuarioExists(int id)
        {
          return (_context.Prontuario?.Any(e => e.ID_Prontuario == id)).GetValueOrDefault();
        }
    }
}
