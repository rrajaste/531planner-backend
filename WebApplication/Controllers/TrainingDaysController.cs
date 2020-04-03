using System;

using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;

using Domain;
using Extensions;

namespace WebApplication.Controllers
{
    public class TrainingDaysController : Controller
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public TrainingDaysController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: TrainingDays
        public async Task<IActionResult> Index(Guid id)
        {
            return View(await _unitOfWork.TrainingDays.AllWithTrainingWeekIdAsyncAuthorize(id, User.UserId()));
        }

        // GET: TrainingDays/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDay = await _unitOfWork.TrainingDays.FindAsyncAuthorize(id, User.UserId());
            if (trainingDay == null)
            {
                return NotFound();
            }

            return View(trainingDay);
        }

        // GET: TrainingDays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,TrainingWeekId,TrainingDayTypeId,Id,CreatedAt,ClosedAt,Comment")] TrainingDay trainingDay)
        {
            if (ModelState.IsValid)
            {
                trainingDay.Id = Guid.NewGuid();
                _unitOfWork.TrainingDays.Add(trainingDay);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingDay);
        }

        // GET: TrainingDays/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDay = await _unitOfWork.TrainingDays.FindAsync(id);
            if (trainingDay == null)
            {
                return NotFound();
            }
            return View(trainingDay);
        }

        // POST: TrainingDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Date,TrainingWeekId,TrainingDayTypeId,Id,CreatedAt,ClosedAt,Comment")] TrainingDay trainingDay)
        {
            if (id != trainingDay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _unitOfWork.TrainingDays.Update(trainingDay);
                await _unitOfWork.SaveChangesAsync();
           
                return RedirectToAction(nameof(Index));
            }
            return View(trainingDay);
        }

        // GET: TrainingDays/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDay = await _unitOfWork.TrainingDays.FindAsyncAuthorize(id, User.UserId());
            if (trainingDay == null)
            {
                return NotFound();
            }

            return View(trainingDay);
        }

        // POST: TrainingDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trainingDay = await _unitOfWork.TrainingDays.FindAsync(id);
            _unitOfWork.TrainingDays.Remove(trainingDay);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
