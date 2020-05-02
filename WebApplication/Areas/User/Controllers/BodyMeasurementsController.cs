using System;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class BodyMeasurementsController : Controller
    {
        private readonly IAppUnitOfWork _bll;

        public BodyMeasurementsController(IAppUnitOfWork unitOfWork)
        {
            _bll = unitOfWork;
        }

        // GET: BodyMeasurements
        public async Task<IActionResult> Index()
        {
            return View(await _bll.BodyMeasurements.AllWithAppUserIdAsync(User.UserId()));
        }

        // GET: BodyMeasurements/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bodyMeasurements = await _bll.BodyMeasurements.FindWithAppUserIdAsync(id, User.UserId());
            if (bodyMeasurements == null)
            {
                return NotFound();
            }

            return View(bodyMeasurements);
        }

        // GET: BodyMeasurements/Create
        public async Task<ViewResult> Create()
        {
            var viewModel = new BodyMeasurementCreateEditViewModel();
            var unitTypes = await _bll.UnitTypes.AllAsync();
            viewModel.UnitTypeSelectList = new SelectList(unitTypes, nameof(UnitType.Id), nameof(UnitType.Name));
            return View(viewModel);
        }

        // POST: BodyMeasurements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BodyMeasurementCreateEditViewModel viewModel)
        { 
            if (ModelState.IsValid)
            {
                viewModel.BodyMeasurement.AppUserId = User.UserId();
                _bll.BodyMeasurements.Add(viewModel.BodyMeasurement);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var unitTypes = await _bll.UnitTypes.AllAsync();
            viewModel.UnitTypeSelectList = new SelectList(
                unitTypes, nameof(UnitType.Id), nameof(UnitType.Name), viewModel.BodyMeasurement.UnitTypeId);
            return View(viewModel);
        }

        // GET: BodyMeasurements/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new BodyMeasurementCreateEditViewModel
            {
                BodyMeasurement = await _bll.BodyMeasurements.FindWithAppUserIdAsync(id, User.UserId())
            };
            var unitTypes = await _bll.UnitTypes.AllAsync();
            viewModel.UnitTypeSelectList = new SelectList(
                unitTypes, nameof(UnitType.Id), nameof(UnitType.Name), viewModel.BodyMeasurement.UnitTypeId);
            if (viewModel.BodyMeasurement == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: BodyMeasurements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, BodyMeasurementCreateEditViewModel viewModel)
        {
            if (id != viewModel.BodyMeasurement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                viewModel.BodyMeasurement.AppUserId = User.UserId();   
                _bll.BodyMeasurements.Update(viewModel.BodyMeasurement);
                await _bll.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            var unitTypes = _bll.BodyMeasurements.All();
            viewModel.UnitTypeSelectList = new SelectList(
                unitTypes, nameof(UnitType.Id), nameof(UnitType.Name), viewModel.BodyMeasurement.UnitTypeId);
            return View(viewModel);
        }

        // GET: BodyMeasurements/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyMeasurements = await _bll.BodyMeasurements.FindAsync(id);
            if (bodyMeasurements == null)
            {
                return NotFound();
            }

            return View(bodyMeasurements);
        }

        // POST: BodyMeasurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bodyMeasurements = await _bll.BodyMeasurements.FindWithAppUserIdAsync(id, User.UserId());
            if (bodyMeasurements == null)
            {
                return NotFound();
            }
            _bll.BodyMeasurements.Remove(bodyMeasurements);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
