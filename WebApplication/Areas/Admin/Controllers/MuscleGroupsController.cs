using System;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("admin")]
    public class MuscleGroupsController : Controller
    {
        private readonly IAppBLL _bll;

        public MuscleGroupsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: MuscleGroups
        public async Task<IActionResult> Index()
        {
            return View(await _bll.MuscleGroups.AllAsync());
        }

        // GET: MuscleGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var muscleGroup = await _bll.MuscleGroups.FindAsync((Guid) id);
            if (muscleGroup == null) return NotFound();

            return View(muscleGroup);
        }

        // GET: MuscleGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MuscleGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Id,CreatedAt,DeletedAt,Comment")]
            MuscleGroup muscleGroup)
        {
            if (ModelState.IsValid)
            {
                _bll.MuscleGroups.Add(muscleGroup);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(muscleGroup);
        }

        // GET: MuscleGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var muscleGroup = await _bll.MuscleGroups.FindAsync((Guid) id);
            if (muscleGroup == null) return NotFound();
            return View(muscleGroup);
        }

        // POST: MuscleGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,Id,CreatedAt,DeletedAt,Comment")]
            MuscleGroup muscleGroup)
        {
            if (id != muscleGroup.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _bll.MuscleGroups.Update(muscleGroup);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(muscleGroup);
        }

        // GET: MuscleGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var muscleGroup = await _bll.MuscleGroups.FindAsync((Guid) id);
            if (muscleGroup == null) return NotFound();

            return View(muscleGroup);
        }

        // POST: MuscleGroups/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var muscleGroup = await _bll.MuscleGroups.FindAsync(id);
            _bll.MuscleGroups.Remove(muscleGroup);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}