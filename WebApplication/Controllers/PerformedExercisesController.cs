using System;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Extensions;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{
    [Authorize]
    public class PerformedExercisesController : Controller
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public PerformedExercisesController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: PerformedExercises

        public async Task<IActionResult> Index()
        { 
            return View(await _unitOfWork.PerformedExercises.AllAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performedExercise = await _unitOfWork.PerformedExercises.FindAsync(id);
            if (performedExercise == null)
            {
                return NotFound();
            }

            return View(performedExercise);
        }

        // GET: PerformedExercises/Details/5

        // GET: PerformedExercises/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: PerformedExercises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NrOfReps,NrOfSets,Weight,Distance,Duration,AppUserId,ExerciseId,UnitsTypeId,TrainingDayId,Id,CreatedAt,ClosedAt,Comment")] PerformedExercise performedExercise)
        {
            if (ModelState.IsValid)
            {
                performedExercise.AppUserId = User.UserId();
                _unitOfWork.PerformedExercises.Add(performedExercise);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(performedExercise);
        }

        // GET: PerformedExercises/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performedExercise = await _unitOfWork.PerformedExercises.FindAsync(id);
            if (performedExercise == null)
            {
                return NotFound();
            }
            return View(performedExercise);
        }

        // POST: PerformedExercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("NrOfReps,NrOfSets,Weight,Distance,Duration,AppUserId,ExerciseId,UnitsTypeId,TrainingDayId,Id,CreatedAt,ClosedAt,Comment")] PerformedExercise performedExercise)
        {
            if (id != performedExercise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.PerformedExercises.Update(performedExercise);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(performedExercise);
        }

        // GET: PerformedExercises/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performedExercise = await _unitOfWork.PerformedExercises.FindAsync(id);
            if (performedExercise == null)
            {
                return NotFound();
            }
            return View(performedExercise);
        }

        // POST: PerformedExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var performedExercise = await _unitOfWork.PerformedExercises.FindAsync(id);
            _unitOfWork.PerformedExercises.Remove(performedExercise);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
