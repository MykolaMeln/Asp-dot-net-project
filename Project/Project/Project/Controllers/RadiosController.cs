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
    public class RadiosController : Controller
    {
        private readonly DBContext _context;

        public RadiosController(DBContext context)
        {
            _context = context;
        }

        // GET: Radios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Radio_Stations.ToListAsync());
        }

        // GET: Radios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radio = await _context.Radio_Stations
                .FirstOrDefaultAsync(m => m.RadioId == id);
            if (radio == null)
            {
                return NotFound();
            }

            return View(radio);
        }

        // GET: Radios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Radios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RadioId,Name,Frequency,Rating")] Radio radio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(radio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(radio);
        }

        // GET: Radios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radio = await _context.Radio_Stations.FindAsync(id);
            if (radio == null)
            {
                return NotFound();
            }
            return View(radio);
        }

        // POST: Radios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RadioId,Name,Frequency,Rating")] Radio radio)
        {
            if (id != radio.RadioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(radio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RadioExists(radio.RadioId))
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
            return View(radio);
        }

        // GET: Radios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radio = await _context.Radio_Stations
                .FirstOrDefaultAsync(m => m.RadioId == id);
            if (radio == null)
            {
                return NotFound();
            }

            return View(radio);
        }

        // POST: Radios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var radio = await _context.Radio_Stations.FindAsync(id);
            _context.Radio_Stations.Remove(radio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RadioExists(int id)
        {
            return _context.Radio_Stations.Any(e => e.RadioId == id);
        }
    }
}
