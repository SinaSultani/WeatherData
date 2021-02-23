using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeatherData;

namespace WeatherData.Controllers
{
    public class JoinTablesController : Controller
    {
        private readonly WeatherDataDbContext _context;

        public JoinTablesController(WeatherDataDbContext context)
        {
            _context = context;
        }

        // GET: JoinTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.JoinTables.ToListAsync());
        }

        // GET: JoinTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joinTables = await _context.JoinTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joinTables == null)
            {
                return NotFound();
            }

            return View(joinTables);
        }

        // GET: JoinTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JoinTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeStamp,InsideOrOutside,Temp,AirHumidity,RiskForMold")] JoinTables joinTables)
        {
            if (ModelState.IsValid)
            {
                _context.Add(joinTables);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(joinTables);
        }

        // GET: JoinTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joinTables = await _context.JoinTables.FindAsync(id);
            if (joinTables == null)
            {
                return NotFound();
            }
            return View(joinTables);
        }

        // POST: JoinTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TimeStamp,InsideOrOutside,Temp,AirHumidity,RiskForMold")] JoinTables joinTables)
        {
            if (id != joinTables.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joinTables);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JoinTablesExists(joinTables.Id))
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
            return View(joinTables);
        }

        // GET: JoinTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joinTables = await _context.JoinTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joinTables == null)
            {
                return NotFound();
            }

            return View(joinTables);
        }

        // POST: JoinTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var joinTables = await _context.JoinTables.FindAsync(id);
            _context.JoinTables.Remove(joinTables);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JoinTablesExists(int id)
        {
            return _context.JoinTables.Any(e => e.Id == id);
        }
    }
}
