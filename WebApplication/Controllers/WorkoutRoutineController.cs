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
    public class WorkoutRoutineController : Controller
    {
        private readonly AppDbContext _context;

        public WorkoutRoutineController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkoutRoutine
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkoutRoutines.ToListAsync());
        }

        // GET: WorkoutRoutine/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutRoutine = await _context.WorkoutRoutines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutRoutine == null)
            {
                return NotFound();
            }

            return View(workoutRoutine);
        }

        // GET: WorkoutRoutine/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkoutRoutine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkoutRoutineId,Name,Description,RoutineTypeId,AppUserId,Id,CreatedAt,DeletedAt,Comment")] WorkoutRoutine workoutRoutine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutRoutine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workoutRoutine);
        }

        // GET: WorkoutRoutine/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutRoutine = await _context.WorkoutRoutines.FindAsync(id);
            if (workoutRoutine == null)
            {
                return NotFound();
            }
            return View(workoutRoutine);
        }

        // POST: WorkoutRoutine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("WorkoutRoutineId,Name,Description,RoutineTypeId,AppUserId,Id,CreatedAt,DeletedAt,Comment")] WorkoutRoutine workoutRoutine)
        {
            if (id != workoutRoutine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutRoutine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutRoutineExists(workoutRoutine.Id))
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
            return View(workoutRoutine);
        }

        // GET: WorkoutRoutine/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutRoutine = await _context.WorkoutRoutines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutRoutine == null)
            {
                return NotFound();
            }

            return View(workoutRoutine);
        }

        // POST: WorkoutRoutine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var workoutRoutine = await _context.WorkoutRoutines.FindAsync(id);
            _context.WorkoutRoutines.Remove(workoutRoutine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutRoutineExists(string id)
        {
            return _context.WorkoutRoutines.Any(e => e.Id == id);
        }
    }
}
