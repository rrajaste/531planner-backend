using System;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class ExercisesController : Controller
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public ExercisesController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Exercises
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Exercises.AllAsync());
        }

        // GET: Exercises/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _unitOfWork.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // GET: Exercises/Create
        public IActionResult Create()
        {
            var viewModel = new ExerciseCreateEditViewModel();
            var exerciseTypes = _unitOfWork.ExerciseTypes.All();
            viewModel.ExerciseTypeSelectList = new SelectList(exerciseTypes, nameof(ExerciseType.Id), nameof(ExerciseType.Name));
            return View(viewModel);
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExerciseCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Exercises.Add(viewModel.Exercise);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var exerciseTypes = _unitOfWork.ExerciseTypes.All();
            viewModel.ExerciseTypeSelectList = new SelectList(exerciseTypes, nameof(ExerciseType.Id), nameof(ExerciseType.Name));
            return View(viewModel);
        }

        // GET: Exercises/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var exercise = await _unitOfWork.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            var viewModel = new ExerciseCreateEditViewModel {Exercise = exercise};
            var exerciseTypes = _unitOfWork.ExerciseTypes.All();
            viewModel.ExerciseTypeSelectList = new SelectList(exerciseTypes, nameof(ExerciseType.Id), nameof(ExerciseType.Name));
            return View(viewModel);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ExerciseCreateEditViewModel viewModel)
        {
            if (id != viewModel.Exercise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Exercises.Update(viewModel.Exercise);
                await _unitOfWork.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            var exerciseTypes = _unitOfWork.ExerciseTypes.All();
            viewModel.ExerciseTypeSelectList = new SelectList(exerciseTypes, nameof(ExerciseType.Id), nameof(ExerciseType.Name));
            return View(viewModel);
        }

        // GET: Exercises/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _unitOfWork.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var exercise = await _unitOfWork.Exercises.FindAsync(id);
            _unitOfWork.Exercises.Remove(exercise);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
