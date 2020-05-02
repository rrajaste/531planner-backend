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
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class DailyNutritionIntakesController : Controller
    {
        private readonly IAppUnitOfWork _bll;

        public DailyNutritionIntakesController(IAppUnitOfWork unitOfWork)
        {
            _bll = unitOfWork;
        }

        // GET: DailyNutritionIntakes
        public async Task<IActionResult> Index()
        {
            return View(await _bll.DailyNutritionIntakes.AllWithAppUserIdAsync(User.UserId()));
        }

        // GET: DailyNutritionIntakes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyNutritionIntake = await _bll.DailyNutritionIntakes.FindWithAppUserIdAsync(id, User.UserId());
            if (dailyNutritionIntake == null)
            {
                return NotFound();
            }

            return View(dailyNutritionIntake);
        }

        // GET: DailyNutritionIntakes/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new DailyNutritionIntakeCreateEditViewModel();
            var unitTypes = await _bll.UnitTypes.AllAsync();
            viewModel.UnitTypeSelectList = new SelectList(unitTypes, nameof(UnitType.Id), nameof(UnitType.Name));
            return View(viewModel);
        }

        // POST: DailyNutritionIntakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DailyNutritionIntakeCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.DailyNutritionIntake.AppUserId = User.UserId();
                _bll.DailyNutritionIntakes.Add(viewModel.DailyNutritionIntake);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var unitTypes = await _bll.UnitTypes.AllAsync();
            viewModel.UnitTypeSelectList = new SelectList(
                unitTypes, nameof(UnitType.Id), nameof(UnitType.Name), viewModel.DailyNutritionIntake.UnitTypeId);
            return View(viewModel);
        }

        // GET: DailyNutritionIntakes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = new DailyNutritionIntakeCreateEditViewModel();
            var dailyNutritionIntake = await _bll.DailyNutritionIntakes.FindWithAppUserIdAsync(id, User.UserId());
            viewModel.DailyNutritionIntake = dailyNutritionIntake;
            if (dailyNutritionIntake == null)
            {
                return NotFound();
            }
            var unitTypes = await _bll.UnitTypes.AllAsync();
            viewModel.UnitTypeSelectList = new SelectList(
                unitTypes, nameof(UnitType.Id), nameof(UnitType.Name), viewModel.DailyNutritionIntake.UnitTypeId);
            return View(viewModel);
        }

        // POST: DailyNutritionIntakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DailyNutritionIntakeCreateEditViewModel viewModel)
        {
            if (id != viewModel.DailyNutritionIntake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                viewModel.DailyNutritionIntake.AppUserId = User.UserId();
                _bll.DailyNutritionIntakes.Update(viewModel.DailyNutritionIntake); 
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var unitTypes = await _bll.BodyMeasurements.AllAsync();
            viewModel.UnitTypeSelectList = new SelectList(
                unitTypes, nameof(UnitType.Id), nameof(UnitType.Name), viewModel.DailyNutritionIntake.UnitTypeId);
            return View(viewModel);
        }

        // GET: DailyNutritionIntakes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyNutritionIntake = await _bll.DailyNutritionIntakes.FindWithAppUserIdAsync(id, User.UserId());
            if (dailyNutritionIntake == null)
            {
                return NotFound();
            }
            return View(dailyNutritionIntake);
        }

        // POST: DailyNutritionIntakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dailyNutritionIntake = await _bll.DailyNutritionIntakes.FindWithAppUserIdAsync(id, User.UserId());
            if (dailyNutritionIntake == null)
            {
                return NotFound();
            }
            _bll.DailyNutritionIntakes.Remove(dailyNutritionIntake);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
