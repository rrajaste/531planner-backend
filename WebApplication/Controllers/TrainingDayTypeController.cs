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
    public class TrainingDayTypeController : Controller
    {
        private readonly AppDbContext _context;

        public TrainingDayTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TrainingDayType
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrainingDaysTypes.ToListAsync());
        }

        // GET: TrainingDayType/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDayType = await _context.TrainingDaysTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingDayType == null)
            {
                return NotFound();
            }

            return View(trainingDayType);
        }

        // GET: TrainingDayType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingDayType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingDayTypeId,Name,Description,Id,CreatedAt,DeletedAt,Comment")] TrainingDayType trainingDayType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingDayType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingDayType);
        }

        // GET: TrainingDayType/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDayType = await _context.TrainingDaysTypes.FindAsync(id);
            if (trainingDayType == null)
            {
                return NotFound();
            }
            return View(trainingDayType);
        }

        // POST: TrainingDayType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TrainingDayTypeId,Name,Description,Id,CreatedAt,DeletedAt,Comment")] TrainingDayType trainingDayType)
        {
            if (id != trainingDayType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingDayType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingDayTypeExists(trainingDayType.Id))
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
            return View(trainingDayType);
        }

        // GET: TrainingDayType/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDayType = await _context.TrainingDaysTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingDayType == null)
            {
                return NotFound();
            }

            return View(trainingDayType);
        }

        // POST: TrainingDayType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var trainingDayType = await _context.TrainingDaysTypes.FindAsync(id);
            _context.TrainingDaysTypes.Remove(trainingDayType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingDayTypeExists(string id)
        {
            return _context.TrainingDaysTypes.Any(e => e.Id == id);
        }
    }
}
