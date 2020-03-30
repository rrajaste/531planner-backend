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
    public class TrainingWeeksController : Controller
    {
        private readonly AppDbContext _context;

        public TrainingWeeksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TrainingWeeks
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrainingWeeks.ToListAsync());
        }

        // GET: TrainingWeeks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingWeek = await _context.TrainingWeeks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingWeek == null)
            {
                return NotFound();
            }

            return View(trainingWeek);
        }

        // GET: TrainingWeeks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingWeeks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingWeekId,WeekNumber,IsDeload,StartingDate,EndingDate,Id,CreatedAt,ClosedAt,Comment")] TrainingWeek trainingWeek)
        {
            if (ModelState.IsValid)
            {
                trainingWeek.Id = Guid.NewGuid();
                _context.Add(trainingWeek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingWeek);
        }

        // GET: TrainingWeeks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingWeek = await _context.TrainingWeeks.FindAsync(id);
            if (trainingWeek == null)
            {
                return NotFound();
            }
            return View(trainingWeek);
        }

        // POST: TrainingWeeks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TrainingWeekId,WeekNumber,IsDeload,StartingDate,EndingDate,Id,CreatedAt,ClosedAt,Comment")] TrainingWeek trainingWeek)
        {
            if (id != trainingWeek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingWeek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingWeekExists(trainingWeek.Id))
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
            return View(trainingWeek);
        }

        // GET: TrainingWeeks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingWeek = await _context.TrainingWeeks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingWeek == null)
            {
                return NotFound();
            }

            return View(trainingWeek);
        }

        // POST: TrainingWeeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trainingWeek = await _context.TrainingWeeks.FindAsync(id);
            _context.TrainingWeeks.Remove(trainingWeek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingWeekExists(Guid id)
        {
            return _context.TrainingWeeks.Any(e => e.Id == id);
        }
    }
}
