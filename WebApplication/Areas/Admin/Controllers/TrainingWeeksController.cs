using System;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain.App.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Areas.Admin.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = AppRoles.Administrator)]
    public class TrainingWeeksController : Controller
    {
        private readonly IAppBLL _bll;

        public TrainingWeeksController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        public async Task<IActionResult> Index(Guid id)
        {
          
            if (!await _bll.WorkoutRoutines.BaseRoutineWithIdExistsAsync(id))
            {
                return NotFound();
            }
            var trainingWeeks = await _bll.TrainingWeeks.AllWithBaseRoutineIdAsync(id);
            var workoutRoutineName = (await _bll.WorkoutRoutines.FindBaseRoutineAsync(id)).Name;
            var viewModel = new TrainingWeekIndexViewModel()
            {
                TrainingWeeks = trainingWeeks.OrderBy(w => w.WeekNumber),
                WorkoutRoutineName = workoutRoutineName
            };
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingWeekCreateViewModel viewModel)
        {
            if (await _bll.WorkoutRoutines.BaseRoutineWithIdExistsAsync(viewModel.WorkoutRoutineId))
            {
                await _bll.TrainingWeeks.AddNewWeekToBaseRoutineWithIdAsync(viewModel.WorkoutRoutineId, viewModel.IsDeload);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id = viewModel.WorkoutRoutineId});
            }
            return BadRequest();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TrainingWeekDeloadEditViewModel viewModel)
        {
            if (await _bll.TrainingWeeks.IsPartOfBaseRoutineAsync(viewModel.TrainingWeekId))
            {
                var trainingWeek = await _bll.TrainingWeeks.FindAsync(viewModel.TrainingWeekId);
                trainingWeek.IsDeload = viewModel.IsDeload;
                _bll.TrainingWeeks.Update(trainingWeek);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id = viewModel.WorkoutRoutineId});
            }
            return BadRequest();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(TrainingWeekViewModel viewModel)
        {
            if (await _bll.TrainingWeeks.IsPartOfBaseRoutineAsync(viewModel.TrainingWeek.Id) && 
                (await _bll.WorkoutRoutines.BaseRoutineWithIdExistsAsync(viewModel.WorkoutRoutineId)))
            {
                await _bll.TrainingWeeks.RemoveAsync(viewModel.TrainingWeek.Id);
                await _bll.SaveChangesAsync();
                await _bll.TrainingWeeks.NormalizeWeekNumbersAsync(viewModel.WorkoutRoutineId);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id = viewModel.WorkoutRoutineId});
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> DecrementWeekNumber(TrainingWeekNumberEditViewModel viewModel)
        {
            if (await _bll.TrainingWeeks.IsPartOfBaseRoutineAsync(viewModel.TrainingWeekId))
            {
                await _bll.TrainingWeeks.DecrementWeekNumberAsync(viewModel.TrainingWeekId);
                await _bll.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index), new {id = viewModel.WorkoutRoutineId});
        }
        
        
        [HttpPost]
        public async Task<IActionResult> IncrementWeekNumber(TrainingWeekNumberEditViewModel viewModel)
        {
            if (await _bll.TrainingWeeks.IsPartOfBaseRoutineAsync(viewModel.TrainingWeekId))
            {
                await _bll.TrainingWeeks.IncrementWeekNumberAsync(viewModel.TrainingWeekId);
                await _bll.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index), new {id = viewModel.WorkoutRoutineId});
        }
    }
}
