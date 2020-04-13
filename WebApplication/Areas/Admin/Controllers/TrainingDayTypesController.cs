using System;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("admin")]
    public class TrainingDayTypesController : Controller
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public TrainingDayTypesController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: TrainingDayTypes
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.TrainingDayTypes.AllAsync());
        }

        // GET: TrainingDayTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDayType = await _unitOfWork.TrainingDayTypes.FindAsync(id);
            if (trainingDayType == null)
            {
                return NotFound();
            }

            return View(trainingDayType);
        }

        // GET: TrainingDayTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingDayTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingDayTypeId,Name,Description,Id,CreatedAt,DeletedAt,Comment")] TrainingDayType trainingDayType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TrainingDayTypes.Add(trainingDayType);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingDayType);
        }

        // GET: TrainingDayTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDayType = await _unitOfWork.TrainingDayTypes.FindAsync(id);
            if (trainingDayType == null)
            {
                return NotFound();
            }
            return View(trainingDayType);
        }

        // POST: TrainingDayTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TrainingDayTypeId,Name,Description,Id,CreatedAt,DeletedAt,Comment")] TrainingDayType trainingDayType)
        {
            if (id != trainingDayType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.TrainingDayTypes.Update(trainingDayType);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingDayType);
        }

        // GET: TrainingDayTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDayType = await _unitOfWork.TrainingDayTypes.FindAsync(id);
            if (trainingDayType == null)
            {
                return NotFound();
            }

            return View(trainingDayType);
        }

        // POST: TrainingDayTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trainingDayType = await _unitOfWork.TrainingDayTypes.FindAsync(id);
            _unitOfWork.TrainingDayTypes.Remove(trainingDayType);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
