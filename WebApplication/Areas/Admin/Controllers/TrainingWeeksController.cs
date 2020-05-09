using System;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Areas.Admin.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
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
            return View(trainingWeeks);
        }
        
        public async Task<IActionResult> Create(Guid id)
        {
            if (!await _bll.WorkoutRoutines.BaseRoutineWithIdExistsAsync(id))
            {
                return NotFound();
            }

            var trainingCycle = await _bll.TrainingCycles.FindWithBaseRoutineIdAsync(id);
            var viewModel = new TrainingWeekViewModel()
            {
                TrainingWeek = new TrainingWeek(){TrainingCycleId = trainingCycle.Id},
                WorkoutRoutineId = id
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingWeekViewModel viewModel)
        {
            if (!await _bll.TrainingCycles.IsPartOfBaseRoutineAsync(viewModel.TrainingWeek.TrainingCycleId))
            {
                return BadRequest();
            }
            viewModel.TrainingWeek.Id = new Guid();
            if (ModelState.IsValid)
            {
                
                _bll.TrainingWeeks.Add(viewModel.TrainingWeek);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id = viewModel.WorkoutRoutineId});
            }
            return View(viewModel);
        }
        
        public async Task<IActionResult> Edit(Guid id)
        {
            if (await _bll.TrainingWeeks.IsPartOfBaseRoutineAsync(id))
            {
                var trainingWeek = await _bll.TrainingWeeks.FindAsync(id);
                var trainingCycle = await _bll.TrainingCycles.FindAsync(trainingWeek.TrainingCycleId);
                var viewModel = new TrainingWeekViewModel()
                {
                    TrainingWeek = trainingWeek,
                    WorkoutRoutineId = trainingCycle.WorkoutRoutineId
                };
                return View(viewModel);
            }
            return NotFound();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TrainingWeekViewModel viewModel)
        {
            if (id != viewModel.TrainingWeek.Id)
            {
                return NotFound();
            }
            if (await _bll.TrainingWeeks.IsPartOfBaseRoutineAsync(viewModel.TrainingWeek.Id))
            {
                if (ModelState.IsValid)
                {
                    _bll.TrainingWeeks.Update(viewModel.TrainingWeek);
                    await _bll.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new {id = viewModel.WorkoutRoutineId});
                }
                return View(viewModel);
            }
            return BadRequest();
        }

        // GET: TrainingWeeks/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _bll.TrainingWeeks.IsPartOfBaseRoutineAsync(id))
            {
                var trainingWeek = await _bll.TrainingWeeks.FindAsync(id);
                var trainingCycle = await _bll.TrainingCycles.FindAsync(trainingWeek.TrainingCycleId);
                var viewModel = new TrainingWeekViewModel()
                {
                    TrainingWeek = trainingWeek,
                    WorkoutRoutineId = trainingCycle.WorkoutRoutineId
                };
                return View(viewModel);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, TrainingWeekViewModel viewModel)
        {
            if (await _bll.TrainingWeeks.IsPartOfBaseRoutineAsync(id))
            {
                var trainingWeek = await _bll.TrainingWeeks.FindAsync(id);
                _bll.TrainingWeeks.Remove(trainingWeek);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id = viewModel.WorkoutRoutineId});
            }
            return BadRequest();
        }
    }
}
