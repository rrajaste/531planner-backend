using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Areas.Admin.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class ExercisesController : Controller
    {
        private readonly IAppBLL _bll;

        public ExercisesController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Exercises.AllAsync());
        }
        
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _bll.Exercises.FindAsync((Guid) id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }
        
        public IActionResult Create()
        {
            var viewModel = new ExerciseCreateEditViewModel();
            var exerciseTypes = _bll.ExerciseTypes.All();
            viewModel.ExerciseTypeSelectList = new SelectList(exerciseTypes, nameof(ExerciseType.Id), nameof(ExerciseType.Name));
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExerciseCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _bll.Exercises.Add(viewModel.Exercise);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var exerciseTypes = _bll.ExerciseTypes.All();
            viewModel.ExerciseTypeSelectList = new SelectList(exerciseTypes, nameof(ExerciseType.Id), nameof(ExerciseType.Name));
            return View(viewModel);
        }
        
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var exercise = await _bll.Exercises.FindAsync((Guid) id);
            if (exercise == null)
            {
                return NotFound();
            }

            var viewModel = new ExerciseCreateEditViewModel {Exercise = exercise};
            var exerciseTypes = _bll.ExerciseTypes.All();
            viewModel.ExerciseTypeSelectList = new SelectList(exerciseTypes, nameof(ExerciseType.Id), nameof(ExerciseType.Name));
            return View(viewModel);
        }
        
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
                _bll.Exercises.Update(viewModel.Exercise);
                await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            var exerciseTypes = _bll.ExerciseTypes.All();
            viewModel.ExerciseTypeSelectList = new SelectList(exerciseTypes, nameof(ExerciseType.Id), nameof(ExerciseType.Name));
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var exercise = await _bll.Exercises.FindAsync((Guid) id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var exercise = await _bll.Exercises.FindAsync(id);
            _bll.Exercises.Remove(exercise);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
