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
    public class RoutineTypesController : Controller
    {
        private readonly IAppBLL _bll;

        public RoutineTypesController(IAppBLL unitOfWork)
        {
            _bll = unitOfWork;
        }

        // GET: RoutineTypes
        public async Task<IActionResult> Index()
        {
            return View(await _bll.RoutineTypes.AllAsync());
        }

        // GET: RoutineTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routineType = await _bll.RoutineTypes.FindAsync((Guid) id);
            if (routineType == null)
            {
                return NotFound();
            }

            return View(routineType);
        }

        // GET: RoutineTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoutineTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoutineType routineType)
        {
            if (ModelState.IsValid)
            {
                _bll.RoutineTypes.Add(routineType);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routineType);
        }

        // GET: RoutineTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routineType = await _bll.RoutineTypes.FindAsync((Guid) id);
            if (routineType == null)
            {
                return NotFound();
            }
            return View(routineType);
        }

        // POST: RoutineTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RoutineType routineType)
        {
            if (id != routineType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _bll.RoutineTypes.Update(routineType);
                await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(routineType);
        }

        // GET: RoutineTypes/Delete/5 
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routineType = await _bll.RoutineTypes.FindAsync((Guid) id); 
            if (routineType == null)
            {
                return NotFound();
            }

            return View(routineType);
        }

        // POST: RoutineTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var routineType = await _bll.RoutineTypes.FindAsync(id);
            _bll.RoutineTypes.Remove(routineType);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
