using System;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class TrainingWeeksController : Controller
    {
        private readonly IAppUnitOfWork _bll;

        public TrainingWeeksController(IAppUnitOfWork unitOfWork)
        {
            _bll = unitOfWork;
        }

        // GET: TrainingWeeks
        public async Task<IActionResult> Index()
        {
            return View(await _bll.TrainingWeeks.AllAsync());
        }

        // GET: TrainingWeeks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingWeek = await _bll.TrainingWeeks.FindAsync(id);
            if (trainingWeek == null)
            {
                return NotFound();
            }

            return View(trainingWeek);
        }

        // GET: TrainingWeeks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingWeeks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingWeekId,WeekNumber,IsDeload,StartingDate,EndingDate,Id,CreatedAt,ClosedAt,Comment")] TrainingWeek trainingWeek)
        {
            if (ModelState.IsValid)
            {
                _bll.TrainingWeeks.Add(trainingWeek);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingWeek);
        }

        // GET: TrainingWeeks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingWeek = await _bll.TrainingWeeks.FindAsync(id);
            if (trainingWeek == null)
            {
                return NotFound();
            }
            return View(trainingWeek);
        }

        // POST: TrainingWeeks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TrainingWeekId,WeekNumber,IsDeload,StartingDate,EndingDate,Id,CreatedAt,ClosedAt,Comment")] TrainingWeek trainingWeek)
        {
            if (id != trainingWeek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.TrainingWeeks.Update(trainingWeek);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingWeek);
        }

        // GET: TrainingWeeks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingWeek = await _bll.TrainingWeeks.FindAsync(id);
            if (trainingWeek == null)
            {
                return NotFound();
            }

            return View(trainingWeek);
        }

        // POST: TrainingWeeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trainingWeek = await _bll.TrainingWeeks.FindAsync(id);
            _bll.TrainingWeeks.Remove(trainingWeek);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
