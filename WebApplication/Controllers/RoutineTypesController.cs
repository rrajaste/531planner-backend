using System;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{
    [Authorize]
    public class RoutineTypesController : Controller
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public RoutineTypesController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: RoutineTypes
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.RoutineTypes.AllAsync());
        }

        // GET: RoutineTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routineType = await _unitOfWork.RoutineTypes.FindAsync(id);
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
        public async Task<IActionResult> Create([Bind("Name,Description,ClosedAt,Id,CreatedAt,DeletedAt,Comment")] RoutineType routineType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RoutineTypes.Add(routineType);
                await _unitOfWork.SaveChangesAsync();
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

            var routineType = await _unitOfWork.RoutineTypes.FindAsync(id);
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,ClosedAt,Id,CreatedAt,DeletedAt,Comment")] RoutineType routineType)
        {
            if (id != routineType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _unitOfWork.RoutineTypes.Update(routineType);
                await _unitOfWork.SaveChangesAsync();
                
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

            var routineType = await _unitOfWork.RoutineTypes.FindAsync(id); 
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
            var routineType = await _unitOfWork.RoutineTypes.FindAsync(id);
            _unitOfWork.RoutineTypes.Remove(routineType);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
