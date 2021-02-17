﻿using System;
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
    public class DatesController : Controller
    {
        private readonly WeatherDataDbContext _context;

        public DatesController(WeatherDataDbContext context)
        {
            _context = context;
        }

        // GET: Dates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dates.ToListAsync());
        }

        // GET: Dates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var date = await _context.Dates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (date == null)
            {
                return NotFound();
            }

            return View(date);
        }

        // GET: Dates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeStamp")] Date date)
        {
            if (ModelState.IsValid)
            {
                _context.Add(date);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(date);
        }

        // GET: Dates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var date = await _context.Dates.FindAsync(id);
            if (date == null)
            {
                return NotFound();
            }
            return View(date);
        }

        // POST: Dates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TimeStamp")] Date date)
        {
            if (id != date.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(date);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DateExists(date.Id))
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
            return View(date);
        }

        // GET: Dates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var date = await _context.Dates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (date == null)
            {
                return NotFound();
            }

            return View(date);
        }

        // POST: Dates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var date = await _context.Dates.FindAsync(id);
            _context.Dates.Remove(date);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DateExists(int id)
        {
            return _context.Dates.Any(e => e.Id == id);
        }
    }
}
