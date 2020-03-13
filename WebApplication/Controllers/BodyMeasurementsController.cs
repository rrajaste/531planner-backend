using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Extensions;
using Microsoft.AspNetCore.Authorization;


namespace WebApplication.Controllers
{
    [Authorize]
    public class BodyMeasurementsController : Controller
    {
        private readonly AppDbContext _context;

        public BodyMeasurementsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BodyMeasurements
        public async Task<IActionResult> Index()
        {
            var userId = User.UserId();
            return View(await _context.BodyMeasurements.Where(b => b.AppUserId == userId).ToListAsync());
        }

        // GET: BodyMeasurements/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyMeasurements = await _context.BodyMeasurements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bodyMeasurements == null)
            {
                return NotFound();
            }

            return View(bodyMeasurements);
        }

        // GET: BodyMeasurements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BodyMeasurements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Weight,Height,Chest,Waist,Hip,Arm,BodyFatPercentage,AppUserId,UnitsTypeId,Id")] BodyMeasurements bodyMeasurements)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodyMeasurements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bodyMeasurements);
        }

        // GET: BodyMeasurements/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyMeasurements = await _context.BodyMeasurements.FindAsync(id);
            if (bodyMeasurements == null)
            {
                return NotFound();
            }
            return View(bodyMeasurements);
        }

        // POST: BodyMeasurements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Weight,Height,Chest,Waist,Hip,Arm,BodyFatPercentage,AppUserId,UnitsTypeId,Id,CreatedAt,DeletedAt,Comment")] BodyMeasurements bodyMeasurements)
        {
            if (id != bodyMeasurements.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodyMeasurements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodyMeasurementsExists(bodyMeasurements.Id))
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
            return View(bodyMeasurements);
        }

        // GET: BodyMeasurements/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyMeasurements = await _context.BodyMeasurements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bodyMeasurements == null)
            {
                return NotFound();
            }

            return View(bodyMeasurements);
        }

        // POST: BodyMeasurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bodyMeasurements = await _context.BodyMeasurements.FindAsync(id);
            _context.BodyMeasurements.Remove(bodyMeasurements);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodyMeasurementsExists(string id)
        {
            return _context.BodyMeasurements.Any(e => e.Id == id);
        }
    }
}
