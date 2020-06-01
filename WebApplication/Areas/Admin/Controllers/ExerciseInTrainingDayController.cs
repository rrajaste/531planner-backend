using System;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using Domain.App.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Areas.Admin.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = AppRoles.Administrator)]
    public class ExerciseInTrainingDayController : Controller
    {
        private readonly IAppBLL _bll;

        public ExerciseInTrainingDayController(IAppBLL bll)
        {
            _bll = bll;
        }

        public async Task<IActionResult> Create(Guid id)
        {
            if (await _bll.TrainingDays.IsPartOfBaseRoutineAsync(id))
            {
                var viewModel = new ExerciseInTrainingDayCreateEditViewModel
                {
                    ExerciseInTrainingDay = new ExerciseInTrainingDay()
                };
                viewModel.ExerciseInTrainingDay.TrainingDayId = id;
                return View(await AddSelectListsToViewModelAsync(viewModel));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExerciseInTrainingDayCreateEditViewModel viewModel)
        {
            if (await _bll.TrainingDays.IsPartOfBaseRoutineAsync(viewModel.ExerciseInTrainingDay.TrainingDayId))
            {
                if (ModelState.IsValid)
                {
                    viewModel.ExerciseInTrainingDay.Id = Guid.NewGuid();
                    _bll.ExercisesInTrainingDays.Add(viewModel.ExerciseInTrainingDay);
                    await _bll.SaveChangesAsync();
                    return RedirectToAction(nameof(View), "TrainingDays",
                        new {id = viewModel.ExerciseInTrainingDay.TrainingDayId});
                }

                return View(await AddSelectListsToViewModelAsync(viewModel));
            }

            return BadRequest();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (await _bll.ExercisesInTrainingDays.IsPartOfBaseRoutineAsync(id))
            {
                var exerciseInTrainingDay = await _bll.ExercisesInTrainingDays.FindAsync(id);
                var viewModel = new ExerciseInTrainingDayCreateEditViewModel
                {
                    ExerciseInTrainingDay = exerciseInTrainingDay
                };
                return View(await AddSelectListsToViewModelAsync(viewModel));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ExerciseInTrainingDayCreateEditViewModel viewModel)
        {
            if (id != viewModel.ExerciseInTrainingDay.Id) return NotFound();

            if (await _bll.ExercisesInTrainingDays.IsPartOfBaseRoutineAsync(viewModel.ExerciseInTrainingDay.Id))
            {
                if (ModelState.IsValid)
                {
                    _bll.ExercisesInTrainingDays.Update(viewModel.ExerciseInTrainingDay);
                    await _bll.SaveChangesAsync();
                    return RedirectToAction(nameof(View), "TrainingDays",
                        new {id = viewModel.ExerciseInTrainingDay.TrainingDayId});
                }

                return View(await AddSelectListsToViewModelAsync(viewModel));
            }

            return BadRequest();
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (await _bll.ExercisesInTrainingDays.IsPartOfBaseRoutineAsync(id))
            {
                var exerciseInTrainingDay = await _bll.ExercisesInTrainingDays.FindAsync(id);
                _bll.ExercisesInTrainingDays.Remove(exerciseInTrainingDay);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(View), "TrainingDays", new {id = exerciseInTrainingDay.TrainingDayId});
            }

            return BadRequest();
        }

        private async Task<ExerciseInTrainingDayCreateEditViewModel> AddSelectListsToViewModelAsync(
            ExerciseInTrainingDayCreateEditViewModel viewModel)
        {
            var returnViewModel = new ExerciseInTrainingDayCreateEditViewModel();
            var exercises = await _bll.Exercises.AllAsync();
            var exerciseTypes = await _bll.ExerciseTypes.AllAsync();
            returnViewModel.Exercises =
                new SelectList(exercises.OrderBy(e => e.Name), nameof(Exercise.Id), nameof(Exercise.Name));
            returnViewModel.ExerciseTypes =
                new SelectList(exerciseTypes, nameof(ExerciseType.Id), nameof(ExerciseType.Name));
            returnViewModel.ExerciseInTrainingDay = viewModel.ExerciseInTrainingDay;
            return returnViewModel;
        }
    }
}