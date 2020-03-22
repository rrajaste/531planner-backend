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
    public class MuscleGroupsController : Controller
    {
        private readonly MuscleGroupRepository _muscleGroupRepository;

        public MuscleGroupsController(AppDbContext context)
        {
            _muscleGroupRepository = new MuscleGroupRepository(context);
        }

        // GET: MuscleGroups
        public async Task<IActionResult> Index()
        {
            return View(await _muscleGroupRepository.AllAsync());
        }

        // GET: MuscleGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscleGroup = await _muscleGroupRepository.FindAsync(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }

            return View(muscleGroup);
        }

        // GET: MuscleGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MuscleGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Id,CreatedAt,DeletedAt,Comment")] MuscleGroup muscleGroup)
        {
            if (ModelState.IsValid)
            {
                _muscleGroupRepository.Add(muscleGroup);
                await _muscleGroupRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(muscleGroup);
        }

        // GET: MuscleGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscleGroup = await _muscleGroupRepository.FindAsync(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }
            return View(muscleGroup);
        }

        // POST: MuscleGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,Id,CreatedAt,DeletedAt,Comment")] MuscleGroup muscleGroup)
        {
            if (id != muscleGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _muscleGroupRepository.Update(muscleGroup);
                await _muscleGroupRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(muscleGroup);
        }

        // GET: MuscleGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscleGroup = await _muscleGroupRepository.FindAsync(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }

            return View(muscleGroup);
        }

        // POST: MuscleGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var muscleGroup = await _muscleGroupRepository.FindAsync(id);
            _muscleGroupRepository.Remove(muscleGroup);
            await _muscleGroupRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
