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
    public class HumiditiesController : Controller
    {
        private readonly WeatherDataDbContext _context;

        public HumiditiesController(WeatherDataDbContext context)
        {
            _context = context;
        }

        // GET: Humidities
        public async Task<IActionResult> Index()
        {
            var weatherDataDbContext = _context.Humidities.Include(h => h.Enviornment);
            return View(await weatherDataDbContext.ToListAsync());
        }

        // GET: Humidities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var humidity = await _context.Humidities
                .Include(h => h.Enviornment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (humidity == null)
            {
                return NotFound();
            }

            return View(humidity);
        }

        // GET: Humidities/Create
        public IActionResult Create()
        {
            ViewData["EnviornmentId"] = new SelectList(_context.Enviornments, "Id", "Id");
            return View();
        }

        // POST: Humidities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AirHumidity,EnviornmentId")] Humidity humidity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(humidity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnviornmentId"] = new SelectList(_context.Enviornments, "Id", "Id", humidity.EnviornmentId);
            return View(humidity);
        }

        // GET: Humidities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var humidity = await _context.Humidities.FindAsync(id);
            if (humidity == null)
            {
                return NotFound();
            }
            ViewData["EnviornmentId"] = new SelectList(_context.Enviornments, "Id", "Id", humidity.EnviornmentId);
            return View(humidity);
        }

        // POST: Humidities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AirHumidity,EnviornmentId")] Humidity humidity)
        {
            if (id != humidity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(humidity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HumidityExists(humidity.Id))
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
            ViewData["EnviornmentId"] = new SelectList(_context.Enviornments, "Id", "Id", humidity.EnviornmentId);
            return View(humidity);
        }

        // GET: Humidities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var humidity = await _context.Humidities
                .Include(h => h.Enviornment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (humidity == null)
            {
                return NotFound();
            }

            return View(humidity);
        }

        // POST: Humidities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var humidity = await _context.Humidities.FindAsync(id);
            _context.Humidities.Remove(humidity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HumidityExists(int id)
        {
            return _context.Humidities.Any(e => e.Id == id);
        }
    }
}
