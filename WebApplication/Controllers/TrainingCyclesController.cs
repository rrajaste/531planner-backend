using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Extensions;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{
    [Authorize]
    public class TrainingCyclesController : Controller
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public TrainingCyclesController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: TrainingCycles
        public async Task<IActionResult> Index(Guid id)
        {
            return View(await _unitOfWork.TrainingCycles.AllWithRoutineIdAuthorizeAsync(id, User.UserId()));
        }

        // GET: TrainingCycles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingCycle = await _unitOfWork.TrainingCycles.FindAuthorizeAsync(id, User.UserId());
            if (trainingCycle == null)
            {
                return NotFound();
            }

            return View(trainingCycle);
        }

        // GET: TrainingCycles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingCycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingCycle trainingCycle)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TrainingCycles.Add(trainingCycle);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingCycle);
        }

        // GET: TrainingCycles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingCycle = await _unitOfWork.TrainingCycles.FindAsync(id);
            if (trainingCycle == null)
            {
                return NotFound();
            }
            return View(trainingCycle);
        }

        // POST: TrainingCycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("WorkoutRoutineId,CycleNumber,StartingDate,EndingDate,Id,CreatedAt,ClosedAt,Comment")] TrainingCycle trainingCycle)
        {
            if (id != trainingCycle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                _unitOfWork.TrainingCycles.Update(trainingCycle);
                await _unitOfWork.SaveChangesAsync();
           
                
                return RedirectToAction(nameof(Index));
            }
            return View(trainingCycle);
        }

        // GET: TrainingCycles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingCycle = await _unitOfWork.TrainingCycles
                .FindAsync(id);
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
            var trainingCycle = await _unitOfWork.TrainingCycles.FindAsync(id);
            _unitOfWork.TrainingCycles.Remove(trainingCycle);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
