using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApplication.Controllers
{
    public class TrainingDaysController : Controller
    {
        private readonly AppDbContext _context;

        public TrainingDaysController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TrainingDays
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TrainingDays.Include(t => t.TrainingDayType).Include(t => t.TrainingWeek);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TrainingDays/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDay = await _context.TrainingDays
                .Include(t => t.TrainingDayType)
                .Include(t => t.TrainingWeek)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingDay == null)
            {
                return NotFound();
            }

            return View(trainingDay);
        }

        // GET: TrainingDays/Create
        public IActionResult Create()
        {
            ViewData["TrainingDayTypeId"] = new SelectList(_context.TrainingDaysTypes, "Id", "Description");
            ViewData["TrainingWeekId"] = new SelectList(_context.TrainingWeeks, "Id", "Id");
            return View();
        }

        // POST: TrainingDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,TrainingWeekId,TrainingDayTypeId,Id,CreatedAt,ClosedAt,Comment")] TrainingDay trainingDay)
        {
            if (ModelState.IsValid)
            {
                trainingDay.Id = Guid.NewGuid();
                _context.Add(trainingDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrainingDayTypeId"] = new SelectList(_context.TrainingDaysTypes, "Id", "Description", trainingDay.TrainingDayTypeId);
            ViewData["TrainingWeekId"] = new SelectList(_context.TrainingWeeks, "Id", "Id", trainingDay.TrainingWeekId);
            return View(trainingDay);
        }

        // GET: TrainingDays/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDay = await _context.TrainingDays.FindAsync(id);
            if (trainingDay == null)
            {
                return NotFound();
            }
            ViewData["TrainingDayTypeId"] = new SelectList(_context.TrainingDaysTypes, "Id", "Description", trainingDay.TrainingDayTypeId);
            ViewData["TrainingWeekId"] = new SelectList(_context.TrainingWeeks, "Id", "Id", trainingDay.TrainingWeekId);
            return View(trainingDay);
        }

        // POST: TrainingDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Date,TrainingWeekId,TrainingDayTypeId,Id,CreatedAt,ClosedAt,Comment")] TrainingDay trainingDay)
        {
            if (id != trainingDay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingDayExists(trainingDay.Id))
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
            ViewData["TrainingDayTypeId"] = new SelectList(_context.TrainingDaysTypes, "Id", "Description", trainingDay.TrainingDayTypeId);
            ViewData["TrainingWeekId"] = new SelectList(_context.TrainingWeeks, "Id", "Id", trainingDay.TrainingWeekId);
            return View(trainingDay);
        }

        // GET: TrainingDays/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDay = await _context.TrainingDays
                .Include(t => t.TrainingDayType)
                .Include(t => t.TrainingWeek)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingDay == null)
            {
                return NotFound();
            }

            return View(trainingDay);
        }

        // POST: TrainingDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trainingDay = await _context.TrainingDays.FindAsync(id);
            _context.TrainingDays.Remove(trainingDay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingDayExists(Guid id)
        {
            return _context.TrainingDays.Any(e => e.Id == id);
        }
    }
}
