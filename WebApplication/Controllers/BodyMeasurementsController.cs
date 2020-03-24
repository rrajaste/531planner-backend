using System;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using DAL.App.EF;
using DAL.App.EF.Repositories;
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
        private readonly IAppUnitOfWork _unitOfWork;

        public BodyMeasurementsController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: BodyMeasurements
        public async Task<IActionResult> Index()
        {
            var userId = User.UserId();
            return View(await _unitOfWork.BodyMeasurements.AllAsync());
        }

        // GET: BodyMeasurements/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyMeasurements = await _unitOfWork.BodyMeasurements.FindAsync(id);
            if (bodyMeasurements == null)
            {
                return NotFound();
            }

            return View(bodyMeasurements);
        }

        // GET: BodyMeasurements/Create
        public IActionResult Create()
        {
            var viewModel = new BodyMeasurementCreateEditViewModel();
            var unitTypes = _unitOfWork.UnitsTypes.All();
            viewModel.UnitTypeSelectList = new SelectList(unitTypes, nameof(UnitsType.Id), nameof(UnitsType.Name));
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
                viewModel.BodyMeasurements.AppUserId = User.UserId();
                _unitOfWork.BodyMeasurements.Add(viewModel.BodyMeasurements);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var unitTypes = _unitOfWork.BodyMeasurements.All();
            viewModel.UnitTypeSelectList = new SelectList(
                unitTypes, nameof(UnitsType.Id), nameof(UnitsType.Name), viewModel.BodyMeasurements.UnitsTypeId);
            return View(viewModel);
        }

        // GET: BodyMeasurements/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = new BodyMeasurementCreateEditViewModel();
            viewModel.BodyMeasurements = await _unitOfWork.BodyMeasurements.FindAsync(id);
            var unitTypes = _unitOfWork.UnitsTypes.All();
            viewModel.UnitTypeSelectList = new SelectList(
                unitTypes, nameof(UnitsType.Id), nameof(UnitsType.Name), viewModel.BodyMeasurements.UnitsTypeId);
            if (viewModel.BodyMeasurements == null)
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
            if (id != viewModel.BodyMeasurements.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.BodyMeasurements.Update(viewModel.BodyMeasurements);
                await _unitOfWork.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            var unitTypes = _unitOfWork.BodyMeasurements.All();
            viewModel.UnitTypeSelectList = new SelectList(
                unitTypes, nameof(UnitsType.Id), nameof(UnitsType.Name), viewModel.BodyMeasurements.UnitsTypeId);
            return View(viewModel);
        }

        // GET: BodyMeasurements/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyMeasurements = await _unitOfWork.BodyMeasurements.FindAsync(id);
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
            var bodyMeasurements = await _unitOfWork.BodyMeasurements.FindAsync(id);
            _unitOfWork.BodyMeasurements.Remove(bodyMeasurements);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
