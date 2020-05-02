using System;
using System.Threading.Tasks;
using Contracts.DAL.App;
using BLL.App.DTO;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class UnitTypesController : Controller
    {
        private readonly IAppBLL _bll;

        public UnitTypesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: UnitType
        public async Task<IActionResult> Index()
        {
            return View(await _bll.UnitTypes.AllAsync());
        }

        // GET: UnitType/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitType = await _bll.UnitTypes.FindAsync((Guid) id);
            if (unitType == null)
            {
                return NotFound();
            }

            return View(unitType);
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
                _bll.UnitTypes.Add(unitType);
                await _bll.SaveChangesAsync();
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

            var unitType = await _bll.UnitTypes.FindAsync((Guid) id);
            if (unitType == null)
            {
                return NotFound();
            }
            return View(unitType);
        }

        // POST: UnitType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UnitType unitType)
        {
            if (id != unitType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.UnitTypes.Update(unitType);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitType);
        }

        // GET: UnitType/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var UnitType = await _bll.UnitTypes.FindAsync((Guid) id);
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
            var UnitType = await _bll.UnitTypes.FindAsync(id);
            _bll.UnitTypes.Remove(UnitType);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
