using System;
using System.Threading.Tasks;
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
        private readonly BodyMeasurementsRepository _bodyMeasurementsRepository;
        private readonly UnitsTypeRepository _unitsTypeRepository;

        public BodyMeasurementsController(AppDbContext context)
        {
            _bodyMeasurementsRepository = new BodyMeasurementsRepository(context);
            _unitsTypeRepository = new UnitsTypeRepository(context);
        }

        // GET: BodyMeasurements
        public async Task<IActionResult> Index()
        {
            var userId = User.UserId();
            return View(await _bodyMeasurementsRepository.AllWithAppUserIdAsync(userId));
        }

        // GET: BodyMeasurements/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyMeasurements = await _bodyMeasurementsRepository.FindAsync(id);
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
            var unitTypes = _unitsTypeRepository.All();
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
                _bodyMeasurementsRepository.Add(viewModel.BodyMeasurements);
                await _bodyMeasurementsRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var unitTypes = _unitsTypeRepository.All();
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
            var bodyMeasurements = await _bodyMeasurementsRepository.FindAsync(id);
            if (bodyMeasurements == null)
            {
                return NotFound();
            }
            return View(bodyMeasurements);
        }

        // POST: BodyMeasurements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Weight,Height,Chest,Waist,Hip,Arm,BodyFatPercentage")] BodyMeasurements bodyMeasurements)
        {
            if (id != bodyMeasurements.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _bodyMeasurementsRepository.Update(bodyMeasurements);
                await _bodyMeasurementsRepository.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            return View(bodyMeasurements);
        }

        // GET: BodyMeasurements/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyMeasurements = await _bodyMeasurementsRepository.FindAsync(id);
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
            var bodyMeasurements = await _bodyMeasurementsRepository.FindAsync(id);
            _bodyMeasurementsRepository.Remove(bodyMeasurements);
            await _bodyMeasurementsRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
