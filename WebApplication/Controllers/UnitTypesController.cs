using System;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{
    [Authorize]

    public class UnitTypesController : Controller
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public UnitTypesController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: UnitType
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.UnitTypes.AllAsync());
        }

        // GET: UnitType/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var UnitType = await _unitOfWork.UnitTypes.FindAsync(id);
            if (UnitType == null)
            {
                return NotFound();
            }

            return View(UnitType);
        }

        // GET: UnitType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnitType unitType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.UnitTypes.Add(unitType);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitType);
        }

        // GET: UnitType/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var UnitType = await _unitOfWork.UnitTypes.FindAsync(id);
            if (UnitType == null)
            {
                return NotFound();
            }
            return View(UnitType);
        }

        // POST: UnitType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UnitType UnitType)
        {
            if (id != UnitType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.UnitTypes.Update(UnitType);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(UnitType);
        }

        // GET: UnitType/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var UnitType = await _unitOfWork.UnitTypes.FindAsync(id);
            if (UnitType == null)
            {
                return NotFound();
            }

            return View(UnitType);
        }

        // POST: UnitType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var UnitType = await _unitOfWork.UnitTypes.FindAsync(id);
            _unitOfWork.UnitTypes.Remove(UnitType);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
