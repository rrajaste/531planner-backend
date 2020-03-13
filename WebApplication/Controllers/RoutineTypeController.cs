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
    public class RoutineTypeController : Controller
    {
        private readonly AppDbContext _context;

        public RoutineTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RoutineType
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoutineTypes.ToListAsync());
        }

        // GET: RoutineType/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routineType = await _context.RoutineTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (routineType == null)
            {
                return NotFound();
            }

            return View(routineType);
        }

        // GET: RoutineType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoutineType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoutineTypeId,Name,Description,ClosedAt,Id,CreatedAt,DeletedAt,Comment")] RoutineType routineType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(routineType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routineType);
        }

        // GET: RoutineType/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routineType = await _context.RoutineTypes.FindAsync(id);
            if (routineType == null)
            {
                return NotFound();
            }
            return View(routineType);
        }

        // POST: RoutineType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RoutineTypeId,Name,Description,ClosedAt,Id,CreatedAt,DeletedAt,Comment")] RoutineType routineType)
        {
            if (id != routineType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routineType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoutineTypeExists(routineType.Id))
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
            return View(routineType);
        }

        // GET: RoutineType/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routineType = await _context.RoutineTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (routineType == null)
            {
                return NotFound();
            }

            return View(routineType);
        }

        // POST: RoutineType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var routineType = await _context.RoutineTypes.FindAsync(id);
            _context.RoutineTypes.Remove(routineType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoutineTypeExists(string id)
        {
            return _context.RoutineTypes.Any(e => e.Id == id);
        }
    }
}
