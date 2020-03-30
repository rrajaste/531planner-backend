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
    public class TrainingCyclesController : Controller
    {
        private readonly AppDbContext _context;

        public TrainingCyclesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TrainingCycles
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrainingCycles.ToListAsync());
        }

        // GET: TrainingCycles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingCycle = await _context.TrainingCycles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingCycle == null)
            {
                return NotFound();
            }

            return View(trainingCycle);
        }

        // GET: TrainingCycles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingCycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkoutRoutineId,CycleNumber,StartingDate,EndingDate,Id,CreatedAt,ClosedAt,Comment")] TrainingCycle trainingCycle)
        {
            if (ModelState.IsValid)
            {
                trainingCycle.Id = Guid.NewGuid();
                _context.Add(trainingCycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingCycle);
        }

        // GET: TrainingCycles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingCycle = await _context.TrainingCycles.FindAsync(id);
            if (trainingCycle == null)
            {
                return NotFound();
            }
            return View(trainingCycle);
        }

        // POST: TrainingCycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("WorkoutRoutineId,CycleNumber,StartingDate,EndingDate,Id,CreatedAt,ClosedAt,Comment")] TrainingCycle trainingCycle)
        {
            if (id != trainingCycle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingCycle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingCycleExists(trainingCycle.Id))
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
            return View(trainingCycle);
        }

        // GET: TrainingCycles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingCycle = await _context.TrainingCycles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingCycle == null)
            {
                return NotFound();
            }

            return View(trainingCycle);
        }

        // POST: TrainingCycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trainingCycle = await _context.TrainingCycles.FindAsync(id);
            _context.TrainingCycles.Remove(trainingCycle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingCycleExists(Guid id)
        {
            return _context.TrainingCycles.Any(e => e.Id == id);
        }
    }
}
