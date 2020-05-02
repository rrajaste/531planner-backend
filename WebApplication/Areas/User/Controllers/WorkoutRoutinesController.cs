using System;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    
    [Authorize(Roles = "user")]
    public class WorkoutRoutinesController : Controller
    {
        private readonly IAppUnitOfWork _bll;

        public WorkoutRoutinesController(IAppUnitOfWork unitOfWork)
        {
             _bll = unitOfWork;
        }

        // GET: WorkoutRoutines
        public async Task<IActionResult> Index()
        {
            var viewModel = new WorkoutRoutineIndexViewModel()
            {
                ActiveRoutine = await _bll.WorkoutRoutines.ActiveRoutineForUserIdAsync(User.UserId()),
                PreviousRoutines = await _bll.WorkoutRoutines.AllNonActiveRoutinesForUserIdAsync(User.UserId())
            };
            return View(viewModel);
        }

        // GET: WorkoutRoutines/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutRoutine = await _bll.WorkoutRoutines.FindAsync(id);
            if (workoutRoutine == null)
            {
                return NotFound();
            }
            
            return View(workoutRoutine);
        }

        // GET: WorkoutRoutines/Create
        public IActionResult Create()
        {
            var viewModel = new WorkoutRoutineCreateEditViewModel
            {
                RoutineTypeSelectList = new SelectList(
                    _bll.RoutineTypes.All(),
                    nameof(RoutineType.Id),
                    nameof(RoutineType.Name))
            };
            return View(viewModel);
        }

        // POST: WorkoutRoutines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkoutRoutineCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.WorkoutRoutine.Id = Guid.NewGuid();
                _bll.WorkoutRoutines.Add(viewModel.WorkoutRoutine);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: WorkoutRoutines/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutRoutine = await _bll.WorkoutRoutines.FindAsync(id);
            if (workoutRoutine == null)
            {
                return NotFound();
            }
            return View(workoutRoutine);
        }

        // POST: WorkoutRoutines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("WorkoutRoutineId,Name,Description,RoutineTypeId,AppUserId,Id,CreatedAt,ClosedAt,Comment")] WorkoutRoutine workoutRoutine)
        {
            if (id != workoutRoutine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _bll.WorkoutRoutines.Update(workoutRoutine);
                await _bll.SaveChangesAsync();
           
                return RedirectToAction(nameof(Index));
            }
            
            return View(workoutRoutine);
        }

        // GET: WorkoutRoutines/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutRoutine = await _bll.WorkoutRoutines.FindAsync(id);
            if (workoutRoutine == null)
            {
                return NotFound();
            }
            return View(workoutRoutine);
        }

        // POST: WorkoutRoutines/Delete/5
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
