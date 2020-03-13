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
    public class TargetMuscleGroupController : Controller
    {
        private readonly AppDbContext _context;

        public TargetMuscleGroupController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TargetMuscleGroup
        public async Task<IActionResult> Index()
        {
            return View(await _context.TargetMuscleGroups.ToListAsync());
        }

        // GET: TargetMuscleGroup/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetMuscleGroup = await _context.TargetMuscleGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (targetMuscleGroup == null)
            {
                return NotFound();
            }

            return View(targetMuscleGroup);
        }

        // GET: TargetMuscleGroup/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TargetMuscleGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,MuscleGroupId,ExerciseId,Id,CreatedAt,DeletedAt,Comment")] TargetMuscleGroup targetMuscleGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(targetMuscleGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(targetMuscleGroup);
        }

        // GET: TargetMuscleGroup/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetMuscleGroup = await _context.TargetMuscleGroups.FindAsync(id);
            if (targetMuscleGroup == null)
            {
                return NotFound();
            }
            return View(targetMuscleGroup);
        }

        // POST: TargetMuscleGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,MuscleGroupId,ExerciseId,Id,CreatedAt,DeletedAt,Comment")] TargetMuscleGroup targetMuscleGroup)
        {
            if (id != targetMuscleGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(targetMuscleGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TargetMuscleGroupExists(targetMuscleGroup.Id))
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
            return View(targetMuscleGroup);
        }

        // GET: TargetMuscleGroup/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetMuscleGroup = await _context.TargetMuscleGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (targetMuscleGroup == null)
            {
                return NotFound();
            }

            return View(targetMuscleGroup);
        }

        // POST: TargetMuscleGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var targetMuscleGroup = await _context.TargetMuscleGroups.FindAsync(id);
            _context.TargetMuscleGroups.Remove(targetMuscleGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TargetMuscleGroupExists(string id)
        {
            return _context.TargetMuscleGroups.Any(e => e.Id == id);
        }
    }
}
