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

        // public async Task<IActionResult> Inactive() => View(await _bll.WorkoutRoutines.AllInactiveBaseRoutinesAsync());
        //
        // public async Task<IActionResult> Unpublished() => View(await _bll.WorkoutRoutines.AllUnPublishedBaseRoutinesAsync());

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutRoutine = await _bll.WorkoutRoutines.FindBaseRoutineAsync((Guid) id);
            if (workoutRoutine == null)
            {
                return NotFound();
            }

            return View(workoutRoutine);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new WorkoutRoutineCreateEditViewModel
            {
                RoutineTypeSelectList = new SelectList(await _bll.RoutineTypes.GetTypeTreeLeafsAsync(), nameof(RoutineType.Id), nameof(RoutineType.Name))
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkoutRoutineCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var a = _bll.WorkoutRoutines.Add(viewModel.WorkoutRoutine);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            // if (id == null)
            // {
            //     return NotFound();
            // }
            //
            // var workoutRoutine = await _bll.WorkoutRoutines.FindAsync(id);
            // if (workoutRoutine == null)
            // {
            //     return NotFound();
            // }
            // return View(workoutRoutine);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,
            [Bind("WorkoutRoutineId,Name,Description,RoutineTypeId,AppUserId,Id,CreatedAt,ClosedAt,Comment")]
            WorkoutRoutine workoutRoutine)
        {
            // if (id != workoutRoutine.Id)
            // {
            //     return NotFound();
            // }
            //
            // if (ModelState.IsValid)
            // {
            //     
            //     _bll.WorkoutRoutines.Update(workoutRoutine);
            //     await _bll.SaveChangesAsync();
            //
            //     return RedirectToAction(nameof(Index));
            // }
            //
            // return View(workoutRoutine);
            return RedirectToAction(nameof(Index));
        }

        // GET: WorkoutRoutines/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutRoutine = await _bll.WorkoutRoutines.FindBaseRoutineAsync((Guid) id);
            if (workoutRoutine == null)
            {
                return NotFound();
            }

            return View(workoutRoutine);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var workoutRoutine = await _bll.WorkoutRoutines.FindAsync(id);
            _bll.WorkoutRoutines.Remove(workoutRoutine);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
