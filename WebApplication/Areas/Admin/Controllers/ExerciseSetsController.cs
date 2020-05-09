using System;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Areas.Admin.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ExerciseSetsController : Controller
    {
        private readonly IAppBLL _bll;

        public ExerciseSetsController(IAppBLL bll)
        {
            _bll = bll;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            if (await _bll.TrainingDays.IsPartOfBaseRoutineAsync(id))
            {
                return View(await _bll.ExerciseSets.AllWithTrainingDayIdAsync(id));
            }
            return NotFound();
        }
        
        public async Task<IActionResult> Create(Guid id)
        {
            if (await _bll.TrainingDays.IsPartOfBaseRoutineAsync(id))
            {
                var viewModel = new ExerciseSetCreateEditViewModel()
                {
                    ExerciseSet = new ExerciseSet()
                };
                viewModel.ExerciseSet.TrainingDayId = id;
                return View(await AddSelectListsToViewModelAsync(viewModel));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExerciseSetCreateEditViewModel viewModel)
        {
            if (await _bll.TrainingDays.IsPartOfBaseRoutineAsync(viewModel.ExerciseSet.TrainingDayId))
            {
                if (ModelState.IsValid)
                {
                    viewModel.ExerciseSet.Id = Guid.NewGuid();
                    await _bll.ExerciseSets.AddBaseSetAsync(viewModel.ExerciseSet);
                    await _bll.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new {id = viewModel.ExerciseSet.TrainingDayId});
                }
                return View(await AddSelectListsToViewModelAsync(viewModel));
            }
            return BadRequest();
        }
        
        public async Task<IActionResult> Edit(Guid id)
        {
            if (await _bll.ExerciseSets.IsPartOfBaseRoutineAsync(id))
            {
                var exerciseSet = await _bll.ExerciseSets.FindAsync(id);
                var viewModel = new ExerciseSetCreateEditViewModel()
                {
                    ExerciseSet = exerciseSet
                };
                return View(await AddSelectListsToViewModelAsync(viewModel));
            }
            return NotFound();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ExerciseSetCreateEditViewModel viewModel)
        {
            if (id != viewModel.ExerciseSet.Id)
            {
                return NotFound();
            }

            if (await _bll.ExerciseSets.IsPartOfBaseRoutineAsync(viewModel.ExerciseSet.Id))
            {
                if (ModelState.IsValid)
                {
                    _bll.ExerciseSets.Update(viewModel.ExerciseSet);
                    await _bll.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new {id = viewModel.ExerciseSet.TrainingDayId});
                }
                return View(await AddSelectListsToViewModelAsync(viewModel));   
            }
            return BadRequest();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _bll.ExerciseSets.IsPartOfBaseRoutineAsync(id))
            {
                var exerciseSet = await _bll.ExerciseSets.FindAsync(id);
                return View(exerciseSet);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (await _bll.ExerciseSets.IsPartOfBaseRoutineAsync(id))
            {
                var exerciseSet = await _bll.ExerciseSets.FindAsync(id);
                _bll.ExerciseSets.Remove(exerciseSet);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id = exerciseSet.TrainingDayId});
            }
            return BadRequest();
        }
        private async Task<ExerciseSetCreateEditViewModel> AddSelectListsToViewModelAsync(ExerciseSetCreateEditViewModel viewModel)
        {
            var returnViewModel = new ExerciseSetCreateEditViewModel();
            var unitTypes = await _bll.UnitTypes.AllAsync();
            var setTypes = await _bll.SetTypes.AllAsync();
            var exercises = await _bll.Exercises.AllAsync();
            returnViewModel.SetTypes = new SelectList(setTypes, nameof(SetType.Id), nameof(SetType.Name));
            returnViewModel.Exercises = new SelectList(exercises, nameof(Exercise.Id), nameof(Exercise.Name));
            returnViewModel.ExerciseSet = viewModel.ExerciseSet;
            return returnViewModel;
        }
    }
}
