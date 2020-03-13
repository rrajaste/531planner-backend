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
    public class MuscleController : Controller
    {
        private readonly AppDbContext _context;

        public MuscleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Muscle
        public async Task<IActionResult> Index()
        {
            return View(await _context.Muscles.ToListAsync());
        }

        // GET: Muscle/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscle = await _context.Muscles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (muscle == null)
            {
                return NotFound();
            }

            return View(muscle);
        }

        // GET: Muscle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Muscle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,MuscleGroupId,Id,CreatedAt,DeletedAt,Comment")] Muscle muscle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(muscle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(muscle);
        }

        // GET: Muscle/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscle = await _context.Muscles.FindAsync(id);
            if (muscle == null)
            {
                return NotFound();
            }
            return View(muscle);
        }

        // POST: Muscle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,MuscleGroupId,Id,CreatedAt,DeletedAt,Comment")] Muscle muscle)
        {
            if (id != muscle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(muscle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MuscleExists(muscle.Id))
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
            return View(muscle);
        }

        // GET: Muscle/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscle = await _context.Muscles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (muscle == null)
            {
                return NotFound();
            }

            return View(muscle);
        }

        // POST: Muscle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var muscle = await _context.Muscles.FindAsync(id);
            _context.Muscles.Remove(muscle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MuscleExists(string id)
        {
            return _context.Muscles.Any(e => e.Id == id);
        }
    }
}
