using System;
using System.Threading.Tasks;
using Contracts.DAL.App;
using BLL.App.DTO;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("admin")]
    public class TrainingDayTypesController : Controller
    {
        private readonly IAppBLL _bll;

        public TrainingDayTypesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: TrainingDayTypes
        public async Task<IActionResult> Index()
        {
            return View(await _bll.TrainingDayTypes.AllAsync());
        }

        // GET: TrainingDayTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDayType = await _bll.TrainingDayTypes.FindAsync((Guid) id);
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
        public async Task<IActionResult> Create(TrainingDayType trainingDayType)
        {
            if (ModelState.IsValid)
            {
                _bll.TrainingDayTypes.Add(trainingDayType);
                await _bll.SaveChangesAsync();
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

            var trainingDayType = await _bll.TrainingDayTypes.FindAsync((Guid) id);
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
        public async Task<IActionResult> Edit(Guid id, TrainingDayType trainingDayType)
        {
            if (id != trainingDayType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.TrainingDayTypes.Update(trainingDayType);
                await _bll.SaveChangesAsync();
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

            var trainingDayType = await _bll.TrainingDayTypes.FindAsync((Guid) id);
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
            var trainingDayType = await _bll.TrainingDayTypes.FindAsync(id);
            _bll.TrainingDayTypes.Remove(trainingDayType);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
