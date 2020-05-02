using System;

using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;

using Domain;
using Extensions;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class TrainingDaysController : Controller
    {
        private readonly IAppUnitOfWork _bll;

        public TrainingDaysController(IAppUnitOfWork unitOfWork)
        {
            _bll = unitOfWork;
        }

        // GET: TrainingDays
        public async Task<IActionResult> Index(Guid id)
        {
            return View(await _bll.TrainingDays.AllWithTrainingWeekIdAsyncAuthorize(id, User.UserId()));
        }

        // GET: TrainingDays/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDay = await _bll.TrainingDays.FindAsyncAuthorize(id, User.UserId());
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
                _bll.TrainingDays.Add(trainingDay);
                await _bll.SaveChangesAsync();
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

            var trainingDay = await _bll.TrainingDays.FindAsync(id);
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
                
                _bll.TrainingDays.Update(trainingDay);
                await _bll.SaveChangesAsync();
           
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

            var trainingDay = await _bll.TrainingDays.FindAsyncAuthorize(id, User.UserId());
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
            var trainingDay = await _bll.TrainingDays.FindAsync(id);
            _bll.TrainingDays.Remove(trainingDay);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
