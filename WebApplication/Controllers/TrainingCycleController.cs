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
    public class TrainingCycleController : Controller
    {
        private readonly AppDbContext _context;

        public TrainingCycleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TrainingCycle
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrainingCycles.ToListAsync());
        }

        // GET: TrainingCycle/Details/5
        public async Task<IActionResult> Details(string id)
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

        // GET: TrainingCycle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingCycle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkoutRoutineId,CycleNumber,StartingDate,EndingDate,Id,CreatedAt,DeletedAt,Comment")] TrainingCycle trainingCycle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingCycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingCycle);
        }

        // GET: TrainingCycle/Edit/5
        public async Task<IActionResult> Edit(string id)
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

        // POST: TrainingCycle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("WorkoutRoutineId,CycleNumber,StartingDate,EndingDate,Id,CreatedAt,DeletedAt,Comment")] TrainingCycle trainingCycle)
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

        // GET: TrainingCycle/Delete/5
        public async Task<IActionResult> Delete(string id)
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

        // POST: TrainingCycle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var trainingCycle = await _context.TrainingCycles.FindAsync(id);
            _context.TrainingCycles.Remove(trainingCycle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingCycleExists(string id)
        {
            return _context.TrainingCycles.Any(e => e.Id == id);
        }
    }
}
