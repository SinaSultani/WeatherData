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
    public class TemperaturesController : Controller
    {
        private readonly WeatherDataDbContext _context;

        public TemperaturesController(WeatherDataDbContext context)
        {
            _context = context;
        }

        // GET: Temperatures
        public async Task<IActionResult> Index()
        {
            var weatherDataDbContext = _context.Temperatures.Include(t => t.Enviornment);
            return View(await weatherDataDbContext.ToListAsync());
        }

        // GET: Temperatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperature = await _context.Temperatures
                .Include(t => t.Enviornment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temperature == null)
            {
                return NotFound();
            }

            return View(temperature);
        }

        // GET: Temperatures/Create
        public IActionResult Create()
        {
            ViewData["EnviornmentId"] = new SelectList(_context.Enviornments, "Id", "Id");
            return View();
        }

        // POST: Temperatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temp,EnviornmentId")] Temperature temperature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temperature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnviornmentId"] = new SelectList(_context.Enviornments, "Id", "Id", temperature.EnviornmentId);
            return View(temperature);
        }

        // GET: Temperatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperature = await _context.Temperatures.FindAsync(id);
            if (temperature == null)
            {
                return NotFound();
            }
            ViewData["EnviornmentId"] = new SelectList(_context.Enviornments, "Id", "Id", temperature.EnviornmentId);
            return View(temperature);
        }

        // POST: Temperatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Temp,EnviornmentId")] Temperature temperature)
        {
            if (id != temperature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temperature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemperatureExists(temperature.Id))
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
            ViewData["EnviornmentId"] = new SelectList(_context.Enviornments, "Id", "Id", temperature.EnviornmentId);
            return View(temperature);
        }

        // GET: Temperatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperature = await _context.Temperatures
                .Include(t => t.Enviornment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temperature == null)
            {
                return NotFound();
            }

            return View(temperature);
        }

        // POST: Temperatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temperature = await _context.Temperatures.FindAsync(id);
            _context.Temperatures.Remove(temperature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemperatureExists(int id)
        {
            return _context.Temperatures.Any(e => e.Id == id);
        }
    }
}
