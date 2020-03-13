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
    public class DailyNutritionIntakeController : Controller
    {
        private readonly AppDbContext _context;

        public DailyNutritionIntakeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DailyNutritionIntake
        public async Task<IActionResult> Index()
        {
            return View(await _context.DailyNutritionIntakes.ToListAsync());
        }

        // GET: DailyNutritionIntake/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyNutritionIntake = await _context.DailyNutritionIntakes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dailyNutritionIntake == null)
            {
                return NotFound();
            }

            return View(dailyNutritionIntake);
        }

        // GET: DailyNutritionIntake/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DailyNutritionIntake/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Calories,Protein,Fats,Carbohydrates,AppUserId,UnitsTypeId,Id,CreatedAt,DeletedAt,Comment")] DailyNutritionIntake dailyNutritionIntake)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailyNutritionIntake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dailyNutritionIntake);
        }

        // GET: DailyNutritionIntake/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyNutritionIntake = await _context.DailyNutritionIntakes.FindAsync(id);
            if (dailyNutritionIntake == null)
            {
                return NotFound();
            }
            return View(dailyNutritionIntake);
        }

        // POST: DailyNutritionIntake/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Calories,Protein,Fats,Carbohydrates,AppUserId,UnitsTypeId,Id,CreatedAt,DeletedAt,Comment")] DailyNutritionIntake dailyNutritionIntake)
        {
            if (id != dailyNutritionIntake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailyNutritionIntake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyNutritionIntakeExists(dailyNutritionIntake.Id))
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
            return View(dailyNutritionIntake);
        }

        // GET: DailyNutritionIntake/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyNutritionIntake = await _context.DailyNutritionIntakes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dailyNutritionIntake == null)
            {
                return NotFound();
            }

            return View(dailyNutritionIntake);
        }

        // POST: DailyNutritionIntake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dailyNutritionIntake = await _context.DailyNutritionIntakes.FindAsync(id);
            _context.DailyNutritionIntakes.Remove(dailyNutritionIntake);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyNutritionIntakeExists(string id)
        {
            return _context.DailyNutritionIntakes.Any(e => e.Id == id);
        }
    }
}
