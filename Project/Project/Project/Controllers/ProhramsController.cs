using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers
{
    public class ProhramsController : Controller
    {
        private readonly DBContext _context;

        public ProhramsController(DBContext context)
        {
            _context = context;
        }

        // GET: Prohrams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prohrams.ToListAsync());
        }

        // GET: Prohrams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prohram = await _context.Prohrams
                .FirstOrDefaultAsync(m => m.ProgramId == id);
            if (prohram == null)
            {
                return NotFound();
            }

            return View(prohram);
        }

        // GET: Prohrams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prohrams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramId,radioid,Name_program,Period,Hour_begin,Hour_end")] Prohram prohram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prohram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prohram);
        }

        // GET: Prohrams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prohram = await _context.Prohrams.FindAsync(id);
            if (prohram == null)
            {
                return NotFound();
            }
            return View(prohram);
        }

        // POST: Prohrams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgramId,radioid,Name_program,Period,Hour_begin,Hour_end")] Prohram prohram)
        {
            if (id != prohram.ProgramId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prohram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProhramExists(prohram.ProgramId))
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
            return View(prohram);
        }

        // GET: Prohrams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prohram = await _context.Prohrams
                .FirstOrDefaultAsync(m => m.ProgramId == id);
            if (prohram == null)
            {
                return NotFound();
            }

            return View(prohram);
        }

        // POST: Prohrams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prohram = await _context.Prohrams.FindAsync(id);
            _context.Prohrams.Remove(prohram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProhramExists(int id)
        {
            return _context.Prohrams.Any(e => e.ProgramId == id);
        }
    }
}
