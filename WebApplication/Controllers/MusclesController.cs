using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class MusclesController : Controller
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public MusclesController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Muscles
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Muscles.AllAsync());
        }

        // GET: Muscles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscle = await _unitOfWork.Muscles.FindAsync(id);
                
            if (muscle == null)
            {
                return NotFound();
            }

            return View(muscle);
        }

        // GET: Muscles/Create
        public IActionResult Create()
        {
            var viewModel = new MuscleCreateEditViewModel();
            var muscleGroups = _unitOfWork.MuscleGroups.All();
            viewModel.MuscleGroupSelectList = new SelectList(muscleGroups, nameof(
                MuscleGroup.Id), nameof(MuscleGroup.Name));
            return View(viewModel);
        }

        // POST: Muscles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MuscleCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Muscle.Id = Guid.NewGuid();
                _unitOfWork.Muscles.Add(viewModel.Muscle);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var muscleGroups = _unitOfWork.MuscleGroups.All();
            viewModel.MuscleGroupSelectList = new SelectList(muscleGroups, nameof(
                MuscleGroup.Id), nameof(MuscleGroup.Name));
            return View(viewModel);
        }

        // GET: Muscles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var viewModel = new MuscleCreateEditViewModel
            {
                Muscle = await _unitOfWork.Muscles.FindAsync(id),
                MuscleGroupSelectList = new SelectList(
                    _unitOfWork.MuscleGroups.All(), 
                    nameof(MuscleGroup.Id), 
                    nameof(MuscleGroup.Name))
            };
            if (viewModel.Muscle == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: Muscles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MuscleCreateEditViewModel viewModel)
        {
            if (id != viewModel.Muscle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Muscles.Update(viewModel.Muscle);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.MuscleGroupSelectList = new SelectList(
                _unitOfWork.MuscleGroups.All(),
                nameof(MuscleGroup.Id),
                nameof(MuscleGroup.Name));
            
            return View(viewModel);
        }

        // GET: Muscles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscle = await _unitOfWork.Muscles.FindAsync(id);
            if (muscle == null)
            {
                return NotFound();
            }

            return View(muscle);
        }

        // POST: Muscles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var muscle = await _unitOfWork.Muscles.FindAsync(id);
            _unitOfWork.Muscles.Remove(muscle);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
