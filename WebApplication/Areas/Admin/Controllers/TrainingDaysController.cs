using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using Domain.App.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Areas.Admin.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = AppRoles.Administrator)]
    public class TrainingDaysController : Controller
    {
        private readonly IAppBLL _bll;

        public TrainingDaysController(IAppBLL bll)
        {
            _bll = bll;
        }

        public async Task<IActionResult> View(Guid id)
        {
            if (await _bll.TrainingDays.IsPartOfBaseRoutineAsync(id))
            {
                var viewModel = await GetIndexViewModelAsync(id);
                return View(viewModel);
            }
            return NotFound();
        }

        public async Task<IActionResult> Create(Guid id)
        {
            if (await _bll.TrainingWeeks.IsPartOfBaseRoutineAsync(id))
            {
                var parentRoutine = await _bll.WorkoutRoutines.FindWithWeekIdAsync(id);
                var viewModel = new TrainingDayCreateEditViewModel()
                {
                    TrainingDay = new BaseTrainingDay(){TrainingWeekId = id},
                    WorkoutRoutineId = parentRoutine.Id
                };
                return View(await AddSelectListsToViewModelAsync(viewModel, id));
            }
            return NotFound();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingDayCreateEditViewModel viewModel)
        {
            if (await _bll.TrainingWeeks.IsPartOfBaseRoutineAsync(viewModel.TrainingDay.TrainingWeekId))
            {
                if (ModelState.IsValid)
                {
                    viewModel.TrainingDay.Id = Guid.NewGuid();
                    _bll.TrainingDays.Add(viewModel.TrainingDay);
                    await _bll.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), "TrainingWeeks", new {id = viewModel.WorkoutRoutineId});
                }
                return View(await AddSelectListsToViewModelAsync(viewModel, viewModel.TrainingDay.TrainingWeekId));
            }
            return BadRequest();
        }
        
        public async Task<IActionResult> Edit(Guid id)
        {
            if (await _bll.TrainingDays.IsPartOfBaseRoutineAsync(id))
            {
                var trainingDay = await _bll.TrainingDays.FindAsync(id);
                var parentRoutine = await _bll.WorkoutRoutines.FindWithTrainingDayIdAsync(id);
                var viewModel = new TrainingDayCreateEditViewModel()
                {
                    TrainingDay = trainingDay,
                    WorkoutRoutineId = parentRoutine.Id
                };
                return View(await AddSelectListsToViewModelAsync(viewModel, trainingDay.TrainingWeekId));
            }
            return NotFound();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TrainingDayCreateEditViewModel viewModel)
        {
            if (id != viewModel.TrainingDay.Id)
            {
                return NotFound();
            }
        
            if (await _bll.TrainingDays.IsPartOfBaseRoutineAsync(viewModel.TrainingDay.Id))
            {
                if (ModelState.IsValid)
                {
                    _bll.TrainingDays.Update(viewModel.TrainingDay);
                    await _bll.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), "TrainingWeeks", new {id = viewModel.WorkoutRoutineId});
                }
                return View(await AddSelectListsToViewModelAsync(viewModel, viewModel.TrainingDay.TrainingWeekId));   
            }
            return BadRequest();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(TrainingDayDeleteViewModel viewModel)
        {
            if (await _bll.TrainingDays.IsPartOfBaseRoutineAsync(viewModel.TrainingDayId) &&
                await _bll.TrainingWeeks.IsPartOfBaseRoutineAsync(viewModel.TrainingWeekId))
            {
                await _bll.TrainingDays.RemoveAsync(viewModel.TrainingDayId);
                await _bll.SaveChangesAsync();
                var parentRoutine = await _bll.WorkoutRoutines.FindWithWeekIdAsync(viewModel.TrainingWeekId);
                return RedirectToAction(nameof(Index), "TrainingWeeks", new {id = parentRoutine.Id});
            }
            return BadRequest();
        }

        private async Task<SelectList> GetDaysOfWeekSelectListAsync(Guid trainingWeekId)
        {
            var unusedDaysOfWeek = await _bll.TrainingDays.GetUnusedDaysInWeekWithIdAsync(trainingWeekId);
            var selectListItems = unusedDaysOfWeek.Select(dayOfWeek => new SelectListItem()
            {
                Value = ((int) dayOfWeek).ToString(),
                Text = CultureInfo.CurrentUICulture.DateTimeFormat.GetDayName(dayOfWeek)
            }).ToList();
            var selectList = new SelectList(selectListItems, nameof(SelectListItem.Value), nameof(SelectListItem.Text));
            return selectList;
        }
        
        private async Task<TrainingDayCreateEditViewModel> AddSelectListsToViewModelAsync(TrainingDayCreateEditViewModel viewModel, Guid trainingWeekId)
        {
            var trainingDayTypes = await _bll.TrainingDayTypes.AllAsync();
            var returnViewModel = new TrainingDayCreateEditViewModel()
            {
                TrainingDayTypes = new SelectList(
                    trainingDayTypes, nameof(TrainingDayType.Id), nameof(TrainingDayType.Name)),
                WorkoutRoutineId = viewModel.WorkoutRoutineId,
                DaysOfWeek = await GetDaysOfWeekSelectListAsync(trainingWeekId),
                TrainingDay = viewModel.TrainingDay
            };
            return returnViewModel;
        }

        private async Task<TrainingDayViewModel> GetIndexViewModelAsync(Guid trainingDayId)
        {
            var parentRoutine = await _bll.WorkoutRoutines.FindWithTrainingDayIdAsync(trainingDayId);
            var trainingDay = await _bll.TrainingDays.FindAsync(trainingDayId);
            var viewModel = new TrainingDayViewModel
            {
                WorkoutRoutineId = parentRoutine.Id,
                TrainingDay = trainingDay
            };
            return viewModel;
        }
    }
}
