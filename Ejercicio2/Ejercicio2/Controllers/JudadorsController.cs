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
    public class JudadorsController : Controller
    {
        private readonly MundialContext _context;

        public JudadorsController(MundialContext context)
        {
            _context = context;
        }

        // GET: Judadors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Judador.ToListAsync());
        }

        // GET: Judadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var judador = await _context.Judador
                .SingleOrDefaultAsync(m => m.Id == id);
            if (judador == null)
            {
                return NotFound();
            }

            return View(judador);
        }

        // GET: Judadors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Judadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Nombre,FechaNacimiento,Posicion,Club,Altura,Idsel")] Judador judador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(judador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(judador);
        }

        // GET: Judadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var judador = await _context.Judador.SingleOrDefaultAsync(m => m.Id == id);
            if (judador == null)
            {
                return NotFound();
            }
            return View(judador);
        }

        // POST: Judadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Nombre,FechaNacimiento,Posicion,Club,Altura,Idsel")] Judador judador)
        {
            if (id != judador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(judador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JudadorExists(judador.Id))
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
            return View(judador);
        }

        // GET: Judadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var judador = await _context.Judador
                .SingleOrDefaultAsync(m => m.Id == id);
            if (judador == null)
            {
                return NotFound();
            }

            return View(judador);
        }

        // POST: Judadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var judador = await _context.Judador.SingleOrDefaultAsync(m => m.Id == id);
            _context.Judador.Remove(judador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JudadorExists(int id)
        {
            return _context.Judador.Any(e => e.Id == id);
        }
    }
}
