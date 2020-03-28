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

        // GET: UnitsType
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.UnitTypes.AllAsync());
        }

        // GET: UnitsType/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitsType = await _unitOfWork.UnitTypes.FindAsync(id);
            if (unitsType == null)
            {
                return NotFound();
            }

            return View(unitsType);
        }

        // GET: UnitsType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitsType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Id,CreatedAt,DeletedAt,Comment")] UnitsType unitsType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.UnitTypes.Add(unitsType);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitsType);
        }

        // GET: UnitsType/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitsType = await _unitOfWork.UnitTypes.FindAsync(id);
            if (unitsType == null)
            {
                return NotFound();
            }
            return View(unitsType);
        }

        // POST: UnitsType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,Id,CreatedAt,DeletedAt,Comment")] UnitsType unitsType)
        {
            if (id != unitsType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.UnitTypes.Update(unitsType);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitsType);
        }

        // GET: UnitsType/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitsType = await _unitOfWork.UnitTypes.FindAsync(id);
            if (unitsType == null)
            {
                return NotFound();
            }

            return View(unitsType);
        }

        // POST: UnitsType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var unitsType = await _unitOfWork.UnitTypes.FindAsync(id);
            _unitOfWork.UnitTypes.Remove(unitsType);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
