using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeatherData;
using WeatherData.Models;

namespace WeatherData.Controllers
{
    public class EnviornmentsController : Controller
    {
        private readonly WeatherDataDbContext _context;

        public EnviornmentsController(WeatherDataDbContext context)
        {
            _context = context;
        }

        // GET: Enviornments
        public async Task<IActionResult> Index()
        {
            var weatherDataDbContext = _context.Enviornments.Include(e => e.Time);
            return View(await weatherDataDbContext.ToListAsync());
        }

        // GET: Enviornments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enviornment = await _context.Enviornments
                .Include(e => e.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enviornment == null)
            {
                return NotFound();
            }

            return View(enviornment);
        }

        // GET: Enviornments/Create
        public IActionResult Create()
        {
            ViewData["DateId"] = new SelectList(_context.Dates, "Id", "Id");
            return View();
        }

        // POST: Enviornments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InsideOrOutside,DateId")] Enviornment enviornment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enviornment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DateId"] = new SelectList(_context.Dates, "Id", "Id", enviornment.DateId);
            return View(enviornment);
        }

        // GET: Enviornments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enviornment = await _context.Enviornments.FindAsync(id);
            if (enviornment == null)
            {
                return NotFound();
            }
            ViewData["DateId"] = new SelectList(_context.Dates, "Id", "Id", enviornment.DateId);
            return View(enviornment);
        }

        // POST: Enviornments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InsideOrOutside,DateId")] Enviornment enviornment)
        {
            if (id != enviornment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enviornment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnviornmentExists(enviornment.Id))
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
            ViewData["DateId"] = new SelectList(_context.Dates, "Id", "Id", enviornment.DateId);
            return View(enviornment);
        }

        // GET: Enviornments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enviornment = await _context.Enviornments
                .Include(e => e.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enviornment == null)
            {
                return NotFound();
            }

            return View(enviornment);
        }

        // POST: Enviornments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enviornment = await _context.Enviornments.FindAsync(id);
            _context.Enviornments.Remove(enviornment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnviornmentExists(int id)
        {
            return _context.Enviornments.Any(e => e.Id == id);
        }
    }
}
