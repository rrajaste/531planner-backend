using System;

using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Domain;
using Microsoft.AspNetCore.Authorization;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class WorkoutRoutinesController : Controller
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public WorkoutRoutinesController(IAppUnitOfWork unitOfWork)
        {
             _unitOfWork = unitOfWork;
        }

        // GET: WorkoutRoutines
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.WorkoutRoutines.AllAsync());
        }

        // GET: WorkoutRoutines/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutRoutine = await _unitOfWork.WorkoutRoutines.FindAsync(id);
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
                    _unitOfWork.RoutineTypes.All(),
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
                _unitOfWork.WorkoutRoutines.Add(viewModel.WorkoutRoutine);
                await _unitOfWork.SaveChangesAsync();
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

            var workoutRoutine = await _unitOfWork.WorkoutRoutines.FindAsync(id);
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
                
                _unitOfWork.WorkoutRoutines.Update(workoutRoutine);
                await _unitOfWork.SaveChangesAsync();
           
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

            var workoutRoutine = await _unitOfWork.WorkoutRoutines.FindAsync(id);
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
            var workoutRoutine = await _unitOfWork.WorkoutRoutines.FindAsync(id);
            _unitOfWork.WorkoutRoutines.Remove(workoutRoutine);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
