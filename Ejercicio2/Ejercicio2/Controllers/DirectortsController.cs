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
    public class DirectortsController : Controller
    {
        private readonly MundialContext _context;

        public DirectortsController(MundialContext context)
        {
            _context = context;
        }

        // GET: Directorts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Directort.ToListAsync());
        }

        // GET: Directorts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directort = await _context.Directort
                .SingleOrDefaultAsync(m => m.Id == id);
            if (directort == null)
            {
                return NotFound();
            }

            return View(directort);
        }

        // GET: Directorts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Directorts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Nacionalidad")] Directort directort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(directort);
        }

        // GET: Directorts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directort = await _context.Directort.SingleOrDefaultAsync(m => m.Id == id);
            if (directort == null)
            {
                return NotFound();
            }
            return View(directort);
        }

        // POST: Directorts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Nacionalidad")] Directort directort)
        {
            if (id != directort.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectortExists(directort.Id))
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
            return View(directort);
        }

        // GET: Directorts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directort = await _context.Directort
                .SingleOrDefaultAsync(m => m.Id == id);
            if (directort == null)
            {
                return NotFound();
            }

            return View(directort);
        }

        // POST: Directorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directort = await _context.Directort.SingleOrDefaultAsync(m => m.Id == id);
            _context.Directort.Remove(directort);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectortExists(int id)
        {
            return _context.Directort.Any(e => e.Id == id);
        }
    }
}
