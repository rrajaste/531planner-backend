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
    public class PerformedExerciseController : Controller
    {
        private readonly AppDbContext _context;

        public PerformedExerciseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PerformedExercise
        public async Task<IActionResult> Index()
        {
            return View(await _context.PerformedExercises.ToListAsync());
        }

        // GET: PerformedExercise/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performedExercise = await _context.PerformedExercises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performedExercise == null)
            {
                return NotFound();
            }

            return View(performedExercise);
        }

        // GET: PerformedExercise/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PerformedExercise/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NrOfReps,NrOfSets,Weight,Distance,Duration,AppUserId,ExerciseId,UnitsTypeId,TrainingDayId,WorkoutRoutineId,Id,CreatedAt,DeletedAt,Comment")] PerformedExercise performedExercise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(performedExercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(performedExercise);
        }

        // GET: PerformedExercise/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performedExercise = await _context.PerformedExercises.FindAsync(id);
            if (performedExercise == null)
            {
                return NotFound();
            }
            return View(performedExercise);
        }

        // POST: PerformedExercise/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NrOfReps,NrOfSets,Weight,Distance,Duration,AppUserId,ExerciseId,UnitsTypeId,TrainingDayId,WorkoutRoutineId,Id,CreatedAt,DeletedAt,Comment")] PerformedExercise performedExercise)
        {
            if (id != performedExercise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(performedExercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerformedExerciseExists(performedExercise.Id))
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
            return View(performedExercise);
        }

        // GET: PerformedExercise/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performedExercise = await _context.PerformedExercises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performedExercise == null)
            {
                return NotFound();
            }

            return View(performedExercise);
        }

        // POST: PerformedExercise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var performedExercise = await _context.PerformedExercises.FindAsync(id);
            _context.PerformedExercises.Remove(performedExercise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerformedExerciseExists(string id)
        {
            return _context.PerformedExercises.Any(e => e.Id == id);
        }
    }
}
