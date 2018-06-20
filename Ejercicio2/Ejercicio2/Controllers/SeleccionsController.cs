using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ejercicio2.DBModels;

namespace Ejercicio2.Controllers
{
    public class SeleccionsController : Controller
    {
        private readonly MundialContext _context;

        public SeleccionsController(MundialContext context)
        {
            _context = context;
        }

        // GET: Seleccions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Seleccion.ToListAsync());
        }

        // GET: Seleccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seleccion = await _context.Seleccion
                .SingleOrDefaultAsync(m => m.Id == id);
            if (seleccion == null)
            {
                return NotFound();
            }

            return View(seleccion);
        }

        // GET: Seleccions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seleccions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Grupo,Confederacion,Iddt")] Seleccion seleccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seleccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seleccion);
        }

        // GET: Seleccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seleccion = await _context.Seleccion.SingleOrDefaultAsync(m => m.Id == id);
            if (seleccion == null)
            {
                return NotFound();
            }
            return View(seleccion);
        }

        // POST: Seleccions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Grupo,Confederacion,Iddt")] Seleccion seleccion)
        {
            if (id != seleccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seleccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeleccionExists(seleccion.Id))
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
            return View(seleccion);
        }

        // GET: Seleccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seleccion = await _context.Seleccion
                .SingleOrDefaultAsync(m => m.Id == id);
            if (seleccion == null)
            {
                return NotFound();
            }

            return View(seleccion);
        }

        // POST: Seleccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seleccion = await _context.Seleccion.SingleOrDefaultAsync(m => m.Id == id);
            _context.Seleccion.Remove(seleccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeleccionExists(int id)
        {
            return _context.Seleccion.Any(e => e.Id == id);
        }
    }
}
