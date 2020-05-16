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
    [Authorize(Roles = "admin, user")]
    public class TrainingDaysController : Controller
    {
        private readonly IAppBLL _bll;

        public TrainingDaysController(IAppBLL bll)
        {
            _bll = bll;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            if (await _bll.TrainingWeeks.IsPartOfBaseRoutineAsync(id))
            {
                return View(await _bll.TrainingDays.AllWithTrainingWeekIdAsync(id));
            }
            return NotFound();
        }
        
        public async Task<IActionResult> Create(Guid id)
        {
            if (await _bll.TrainingWeeks.IsPartOfBaseRoutineAsync(id))
            {
                var viewModel = new TrainingDayCreateEditViewModel()
                {
                    TrainingDay = new TrainingDay(){TrainingWeekId = id},
                    TrainingDayTypes = await GetTrainingDayTypesSelectListAsync()
                };
                return View(viewModel);
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
                    return RedirectToAction(nameof(Index), new {id = viewModel.TrainingDay.TrainingWeekId});
                }

                viewModel.TrainingDayTypes = await GetTrainingDayTypesSelectListAsync();
                return View(viewModel);
            }
            return BadRequest();
        }
        
        public async Task<IActionResult> Edit(Guid id)
        {
            if (await _bll.TrainingDays.IsPartOfBaseRoutineAsync(id))
            {
                var trainingDay = await _bll.TrainingDays.FindAsync(id);
                var viewModel = new TrainingDayCreateEditViewModel()
                {
                    TrainingDay = trainingDay,
                    TrainingDayTypes = await GetTrainingDayTypesSelectListAsync()
                };
                return View(viewModel);
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
                    return RedirectToAction(nameof(Index), new {id = viewModel.TrainingDay.TrainingWeekId});
                }
                viewModel.TrainingDayTypes = await GetTrainingDayTypesSelectListAsync();
                return View(viewModel);   
            }
            return BadRequest();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _bll.TrainingDays.IsPartOfBaseRoutineAsync(id))
            {
                var trainingDay = await _bll.TrainingDays.FindAsync(id);
                return View(trainingDay);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (await _bll.TrainingDays.IsPartOfBaseRoutineAsync(id))
            {
                var trainingDay = await _bll.TrainingDays.FindAsync(id);
                _bll.TrainingDays.Remove(trainingDay);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id = trainingDay.TrainingWeekId});
            }
            return BadRequest();
        }

        private async Task<SelectList> GetTrainingDayTypesSelectListAsync()
        {
            var trainingDayTypes = await _bll.TrainingDayTypes.AllAsync();
            var trainingDayTypesSelectList = new SelectList(
                trainingDayTypes,
                nameof(TrainingDayType.Id),
                nameof(TrainingDayType.Name)
                );
            return trainingDayTypesSelectList;
        }
    }
}