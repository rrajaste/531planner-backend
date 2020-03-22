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
    public class TrainingDayTypesController : Controller
    {
        private readonly TrainingDayTypeRepository _trainingDayTypeRepository;

        public TrainingDayTypesController(AppDbContext context)
        {
            _trainingDayTypeRepository = new TrainingDayTypeRepository(context);
        }

        // GET: TrainingDayTypes
        public async Task<IActionResult> Index()
        {
            return View(await _trainingDayTypeRepository.AllAsync());
        }

        // GET: TrainingDayTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDayType = await _trainingDayTypeRepository.FindAsync(id);
            if (trainingDayType == null)
            {
                return NotFound();
            }

            return View(trainingDayType);
        }

        // GET: TrainingDayTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingDayTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingDayTypeId,Name,Description,Id,CreatedAt,DeletedAt,Comment")] TrainingDayType trainingDayType)
        {
            if (ModelState.IsValid)
            {
                _trainingDayTypeRepository.Add(trainingDayType);
                await _trainingDayTypeRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingDayType);
        }

        // GET: TrainingDayTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDayType = await _trainingDayTypeRepository.FindAsync(id);
            if (trainingDayType == null)
            {
                return NotFound();
            }
            return View(trainingDayType);
        }

        // POST: TrainingDayTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TrainingDayTypeId,Name,Description,Id,CreatedAt,DeletedAt,Comment")] TrainingDayType trainingDayType)
        {
            if (id != trainingDayType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _trainingDayTypeRepository.Update(trainingDayType);
                await _trainingDayTypeRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingDayType);
        }

        // GET: TrainingDayTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDayType = await _trainingDayTypeRepository.FindAsync(id);
            if (trainingDayType == null)
            {
                return NotFound();
            }

            return View(trainingDayType);
        }

        // POST: TrainingDayTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trainingDayType = await _trainingDayTypeRepository.FindAsync(id);
            _trainingDayTypeRepository.Remove(trainingDayType);
            await _trainingDayTypeRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
