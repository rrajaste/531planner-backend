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
        
        public async Task<IActionResult> Create(Guid id)
        {
            if (await _bll.ExercisesInTrainingDays.IsPartOfBaseRoutineAsync(id))
            {
                var parentTrainingDay = await _bll.TrainingDays.FindWithExerciseInTrainingDayIdAsync(id);
                var viewModel = new ExerciseSetCreateEditViewModel()
                {
                    ExerciseSet = new BaseLiftSet()
                    {
                        ExerciseInTrainingDayId = id
                    },
                    TrainingDayId = parentTrainingDay.Id
                };
                return View(await AddSelectListsToViewModelAsync(viewModel));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExerciseSetCreateEditViewModel viewModel)
        {
            if (await _bll.ExercisesInTrainingDays.IsPartOfBaseRoutineAsync(viewModel.ExerciseSet.ExerciseInTrainingDayId))
            {
                if (ModelState.IsValid)
                {
                    viewModel.ExerciseSet.Id = Guid.NewGuid();
                    await _bll.ExerciseSets.AddBaseLiftSetAsync(viewModel.ExerciseSet);
                    await _bll.SaveChangesAsync();
                    return RedirectToAction(nameof(View), "TrainingDays", 
                        new {id = viewModel.TrainingDayId});
                }
                return View(await AddSelectListsToViewModelAsync(viewModel));
            }
            return BadRequest();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (await _bll.ExerciseSets.IsPartOfBaseRoutineAsync(id))
            {
                var exerciseSet = await _bll.ExerciseSets.FindBaseLiftSetAsync(id);
                var parentTrainingDay = await _bll.TrainingDays.FindWithExerciseSetIdAsync(id);
                var viewModel = new ExerciseSetCreateEditViewModel()
                {
                    ExerciseSet = exerciseSet,
                    TrainingDayId = parentTrainingDay.Id
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
                    await _bll.ExerciseSets.UpdateAsync(viewModel.ExerciseSet);
                    await _bll.SaveChangesAsync();
                    return RedirectToAction(nameof(View), "TrainingDays", new {id = viewModel.TrainingDayId});
                }
                return View(await AddSelectListsToViewModelAsync(viewModel));   
            }
            return BadRequest();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _bll.ExerciseSets.IsPartOfBaseRoutineAsync(id))
            {
                var parentTrainingDay = await _bll.TrainingDays.FindWithExerciseSetIdAsync(id);
                var removedEntity = await _bll.ExerciseSets.RemoveAsync(id);
                await _bll.SaveChangesAsync();
                await _bll.ExerciseSets.NormalizeSetNumbersAsync(removedEntity.ExerciseInTrainingDayId);
                return RedirectToAction(nameof(View), "TrainingDays", new {id = parentTrainingDay.Id});
            }
            return BadRequest();
        }
        private async Task<ExerciseSetCreateEditViewModel> AddSelectListsToViewModelAsync(ExerciseSetCreateEditViewModel viewModel)
        {
            var returnViewModel = new ExerciseSetCreateEditViewModel();
            var setTypes = await _bll.SetTypes.AllAsync();
            var exercises = await _bll.Exercises.AllAsync();
            returnViewModel.SetTypes = new SelectList(setTypes, nameof(SetType.Id), nameof(SetType.Name));
            returnViewModel.Exercises = new SelectList(exercises, nameof(Exercise.Id), nameof(Exercise.Name));
            returnViewModel.ExerciseSet = viewModel.ExerciseSet;
            returnViewModel.TrainingDayId = viewModel.TrainingDayId;
            return returnViewModel;
        }
    }
}