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
    public class TrainingDayController : Controller
    {
        private readonly AppDbContext _context;

        public TrainingDayController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TrainingDay
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrainingDays.ToListAsync());
        }

        // GET: TrainingDay/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDay = await _context.TrainingDays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingDay == null)
            {
                return NotFound();
            }

            return View(trainingDay);
        }

        // GET: TrainingDay/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingDay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,TrainingWeekId,TrainingDayTypeId,Id,CreatedAt,DeletedAt,Comment")] TrainingDay trainingDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingDay);
        }

        // GET: TrainingDay/Edit/5
        public async Task<IActionResult> Edit(string id)
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
            return View(trainingDay);
        }

        // POST: TrainingDay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Date,TrainingWeekId,TrainingDayTypeId,Id,CreatedAt,DeletedAt,Comment")] TrainingDay trainingDay)
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
            return View(trainingDay);
        }

        // GET: TrainingDay/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDay = await _context.TrainingDays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingDay == null)
            {
                return NotFound();
            }

            return View(trainingDay);
        }

        // POST: TrainingDay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var trainingDay = await _context.TrainingDays.FindAsync(id);
            _context.TrainingDays.Remove(trainingDay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingDayExists(string id)
        {
            return _context.TrainingDays.Any(e => e.Id == id);
        }
    }
}
