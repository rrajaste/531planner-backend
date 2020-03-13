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
    public class ExerciseInTrainingDayController : Controller
    {
        private readonly AppDbContext _context;

        public ExerciseInTrainingDayController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ExerciseInTrainingDay
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExercisesInTrainingDays.ToListAsync());
        }

        // GET: ExerciseInTrainingDay/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseInTrainingDay = await _context.ExercisesInTrainingDays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exerciseInTrainingDay == null)
            {
                return NotFound();
            }

            return View(exerciseInTrainingDay);
        }

        // GET: ExerciseInTrainingDay/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExerciseInTrainingDay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingDayId,ExerciseId,Id,CreatedAt,DeletedAt,Comment")] ExerciseInTrainingDay exerciseInTrainingDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exerciseInTrainingDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exerciseInTrainingDay);
        }

        // GET: ExerciseInTrainingDay/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseInTrainingDay = await _context.ExercisesInTrainingDays.FindAsync(id);
            if (exerciseInTrainingDay == null)
            {
                return NotFound();
            }
            return View(exerciseInTrainingDay);
        }

        // POST: ExerciseInTrainingDay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TrainingDayId,ExerciseId,Id,CreatedAt,DeletedAt,Comment")] ExerciseInTrainingDay exerciseInTrainingDay)
        {
            if (id != exerciseInTrainingDay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exerciseInTrainingDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseInTrainingDayExists(exerciseInTrainingDay.Id))
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
            return View(exerciseInTrainingDay);
        }

        // GET: ExerciseInTrainingDay/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseInTrainingDay = await _context.ExercisesInTrainingDays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exerciseInTrainingDay == null)
            {
                return NotFound();
            }

            return View(exerciseInTrainingDay);
        }

        // POST: ExerciseInTrainingDay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var exerciseInTrainingDay = await _context.ExercisesInTrainingDays.FindAsync(id);
            _context.ExercisesInTrainingDays.Remove(exerciseInTrainingDay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseInTrainingDayExists(string id)
        {
            return _context.ExercisesInTrainingDays.Any(e => e.Id == id);
        }
    }
}
