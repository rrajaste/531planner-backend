using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{
    [Authorize]
    public class UnitsTypeController : Controller
    {
        private readonly UnitsTypeRepository _unitsTypeRepository;

        public UnitsTypeController(AppDbContext context)
        {
            _unitsTypeRepository = new UnitsTypeRepository(context);
        }

        // GET: UnitsType
        public async Task<IActionResult> Index()
        {
            return View(await _unitsTypeRepository.AllAsync());
        }

        // GET: UnitsType/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitsType = await _unitsTypeRepository.FindAsync(id);
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
                _unitsTypeRepository.Add(unitsType);
                await _unitsTypeRepository.SaveChangesAsync();
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

            var unitsType = await _unitsTypeRepository.FindAsync(id);
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
                _unitsTypeRepository.Update(unitsType);
                await _unitsTypeRepository.SaveChangesAsync();
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

            var unitsType = await _unitsTypeRepository.FindAsync(id);
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
            var unitsType = await _unitsTypeRepository.FindAsync(id);
            _unitsTypeRepository.Remove(unitsType);
            await _unitsTypeRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
