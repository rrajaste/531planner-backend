using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using BLL.App.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{

    [Authorize(Roles = "admin")]
    [Area("Admin")]
    public class WorkoutRoutinesController : Controller
    {
        private readonly IAppBLL _bll;

        public WorkoutRoutinesController(IAppBLL bll)
        {
            _bll = bll;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _bll.WorkoutRoutines.AllActiveBaseRoutinesAsync());
        }
        
        public async Task<IActionResult> Create()
        {
            var viewModel = new WorkoutRoutineCreateEditViewModel
            {
                RoutineTypeSelectList = new SelectList(await _bll.RoutineTypes.GetTypeTreeLeafsAsync(), 
                    nameof(RoutineType.Id), nameof(RoutineType.Name))
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkoutRoutineCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _bll.WorkoutRoutines.AddWithBaseCycleAsync(viewModel.WorkoutRoutine);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (await _bll.WorkoutRoutines.BaseRoutineWithIdExistsAsync(id))
            {
                var workoutRoutine = await _bll.WorkoutRoutines.FindBaseRoutineAsync(id);
                var viewModel = new WorkoutRoutineCreateEditViewModel
                {
                    WorkoutRoutine = workoutRoutine,
                    RoutineTypeSelectList = new SelectList(await _bll.RoutineTypes.GetTypeTreeLeafsAsync(), 
                        nameof(RoutineType.Id), nameof(RoutineType.Name))
                };
                return View(viewModel);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, WorkoutRoutine workoutRoutine)
        {
            if (ModelState.IsValid)
            {
                
                _bll.WorkoutRoutines.Update(workoutRoutine);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index), workoutRoutine);
            }
            var viewModel = new WorkoutRoutineCreateEditViewModel
            {
                WorkoutRoutine = workoutRoutine,
                RoutineTypeSelectList = new SelectList(await _bll.RoutineTypes.GetTypeTreeLeafsAsync(), 
                    nameof(RoutineType.Id), nameof(RoutineType.Name))
            };
            return View(viewModel);
        }

        // GET: WorkoutRoutines/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (await _bll.WorkoutRoutines.BaseRoutineWithIdExistsAsync(id))
            {
                var workoutRoutine = await _bll.WorkoutRoutines.FindBaseRoutineAsync(id);
                return View(workoutRoutine);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (await _bll.WorkoutRoutines.BaseRoutineWithIdExistsAsync(id))
            {
                var workoutRoutine = await _bll.WorkoutRoutines.FindAsync(id);
                _bll.WorkoutRoutines.Remove(workoutRoutine);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
