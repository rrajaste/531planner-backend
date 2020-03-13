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
    public class UnitsTypeController : Controller
    {
        private readonly AppDbContext _context;

        public UnitsTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UnitsType
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnitsTypes.ToListAsync());
        }

        // GET: UnitsType/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitsType = await _context.UnitsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitsType == null)
            {
                return NotFound();
            }

            return View(unitsType);
        }

        // GET: UnitsType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitsType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitsTypeId,Name,Description,Id,CreatedAt,DeletedAt,Comment")] UnitsType unitsType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitsType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitsType);
        }

        // GET: UnitsType/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitsType = await _context.UnitsTypes.FindAsync(id);
            if (unitsType == null)
            {
                return NotFound();
            }
            return View(unitsType);
        }

        // POST: UnitsType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UnitsTypeId,Name,Description,Id,CreatedAt,DeletedAt,Comment")] UnitsType unitsType)
        {
            if (id != unitsType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitsType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitsTypeExists(unitsType.Id))
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
            return View(unitsType);
        }

        // GET: UnitsType/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitsType = await _context.UnitsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitsType == null)
            {
                return NotFound();
            }

            return View(unitsType);
        }

        // POST: UnitsType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var unitsType = await _context.UnitsTypes.FindAsync(id);
            _context.UnitsTypes.Remove(unitsType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitsTypeExists(string id)
        {
            return _context.UnitsTypes.Any(e => e.Id == id);
        }
    }
}
