using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using BLL.App.DTO;
using Domain.App.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Areas.Admin.ViewModels;
using WebApplication.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{

    [Area(nameof(Admin))]
    [Authorize(Roles = AppRoles.Administrator)]
    public class WorkoutRoutinesController : Controller
    {
        private readonly IAppBLL _bll;

        public WorkoutRoutinesController(IAppBLL bll)
        {
            _bll = bll;
        }

        public async Task<IActionResult> Index()
        {
            var routines = await _bll.WorkoutRoutines.AllActiveBaseRoutinesAsync();
            var publishedRoutines = new Collection<WorkoutRoutine>();
            var unpublishedRoutines = new Collection<WorkoutRoutine>();
            foreach (var routine in routines)
            {
                if (routine.IsPublished)
                {
                    publishedRoutines.Add(routine);
                }
                else
                {
                    unpublishedRoutines.Add(routine);
                }
            }
            var viewModel = new WorkoutRoutineViewModel()
            {
                PublishedRoutines = publishedRoutines,
                UnPublishedRoutines = unpublishedRoutines
            };
            return View(viewModel);
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
                var workoutRoutineId = Guid.NewGuid();;
                viewModel.WorkoutRoutine.Id = workoutRoutineId;
                await _bll.WorkoutRoutines.AddWithBaseCycleAsync(viewModel.WorkoutRoutine);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "TrainingWeeks", new
                {
                    area = "Admin", id = workoutRoutineId
                });
            }
            viewModel.RoutineTypeSelectList = new SelectList(await _bll.RoutineTypes.GetTypeTreeLeafsAsync(),
                nameof(RoutineType.Id), nameof(RoutineType.Name));
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
        public async Task<IActionResult> Edit(Guid id, WorkoutRoutineCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                
                _bll.WorkoutRoutines.Update(viewModel.WorkoutRoutine);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.RoutineTypeSelectList = new SelectList(await _bll.RoutineTypes.GetTypeTreeLeafsAsync(),
                nameof(RoutineType.Id), nameof(RoutineType.Name));
            
            return View(viewModel);
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
            return BadRequest();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Publish(WorkoutRoutinePublishViewModel viewModel)
        {
            if (await _bll.WorkoutRoutines.BaseRoutineWithIdExistsAsync(viewModel.WorkoutRoutineId))
            {
                await _bll.WorkoutRoutines.ChangeRoutinePublishStatus(viewModel.WorkoutRoutineId, true);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnPublish(WorkoutRoutinePublishViewModel viewModel)
        {
            if (await _bll.WorkoutRoutines.BaseRoutineWithIdExistsAsync(viewModel.WorkoutRoutineId))
            {
                await _bll.WorkoutRoutines.ChangeRoutinePublishStatus(viewModel.WorkoutRoutineId, false);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }
    }
}
