using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{
    [Authorize]
    public class RoutineTypesController : Controller
    {
        private readonly RoutineTypeRepository _routineTypeRepository;

        public RoutineTypesController(AppDbContext context)
        {
            _routineTypeRepository = new RoutineTypeRepository(context);
        }

        // GET: RoutineTypes
        public async Task<IActionResult> Index()
        {
            return View(await _routineTypeRepository.AllAsync());
        }

        // GET: RoutineTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routineType = await _routineTypeRepository.FindAsync(id);
            if (routineType == null)
            {
                return NotFound();
            }

            return View(routineType);
        }

        // GET: RoutineTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoutineTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,ClosedAt,Id,CreatedAt,DeletedAt,Comment")] RoutineType routineType)
        {
            if (ModelState.IsValid)
            {
                _routineTypeRepository.Add(routineType);
                await _routineTypeRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routineType);
        }

        // GET: RoutineTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routineType = await _routineTypeRepository.FindAsync(id);
            if (routineType == null)
            {
                return NotFound();
            }
            return View(routineType);
        }

        // POST: RoutineTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,ClosedAt,Id,CreatedAt,DeletedAt,Comment")] RoutineType routineType)
        {
            if (id != routineType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _routineTypeRepository.Update(routineType);
                await _routineTypeRepository.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(routineType);
        }

        // GET: RoutineTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routineType = await _routineTypeRepository.FindAsync(id); 
            if (routineType == null)
            {
                return NotFound();
            }

            return View(routineType);
        }

        // POST: RoutineTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var routineType = await _routineTypeRepository.FindAsync(id);
            _routineTypeRepository.Remove(routineType);
            await _routineTypeRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
