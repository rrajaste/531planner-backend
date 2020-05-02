using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using BLL.App.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("Admin")]
    public class TrainingCyclesController : Controller
    {
        private readonly IAppBLL _bll;

        public TrainingCyclesController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        public async Task<IActionResult> Index(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _bll.TrainingCycles.AllWithBaseRoutineIdAsync(id));
        }
        
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingCycle = await _bll.TrainingCycles.FindWithBaseRoutineIdAsync((Guid) id);
            if (trainingCycle == null)
            {
                return NotFound();
            }

            return View(trainingCycle);
        }

        public IActionResult Create(Guid id)
        {
            var workoutRoutine = _bll.WorkoutRoutines.Find(id);
            if (!workoutRoutine.IsBaseRoutine)
            {
                return BadRequest();
            }
            return View(new TrainingCycle(){WorkoutRoutineId = workoutRoutine.Id});
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingCycle trainingCycle)
        {
            if (ModelState.IsValid)
            {
                _bll.TrainingCycles.Add(trainingCycle);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingCycle);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trainingCycle = await _bll.TrainingCycles.FindAsync((Guid) id);
            
            if (trainingCycle == null)
            {
                return NotFound();
            }
            return View(trainingCycle);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TrainingCycle trainingCycle)
        {
            if (id != trainingCycle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                _bll.TrainingCycles.Update(trainingCycle);
                await _bll.SaveChangesAsync();
           
                
                return RedirectToAction(nameof(Index));
            }
            return View(trainingCycle);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingCycle = await _bll.TrainingCycles.FindWithBaseRoutineIdAsync((Guid) id);
            if (trainingCycle == null)
            {
                return NotFound();
            }

            return View(trainingCycle);
        }

        // POST: TrainingCycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trainingCycle = await _bll.TrainingCycles.FindAsync(id);
            _bll.TrainingCycles.Remove(trainingCycle);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
