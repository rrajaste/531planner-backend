using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Domain.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Areas.Admin.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("admin")]
    public class MusclesController : Controller
    {
        private readonly IAppBLL _bll;

        public MusclesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Muscles
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Muscles.AllAsync());
        }

        // GET: Muscles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscle = await _bll.Muscles.FindAsync((Guid) id);
                
            if (muscle == null)
            {
                return NotFound();
            }

            return View(muscle);
        }

        // GET: Muscles/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new MuscleCreateEditViewModel();
            var muscleGroups = await _bll.MuscleGroups.AllAsync();
            viewModel.MuscleGroupSelectList = new SelectList(muscleGroups, nameof(
                MuscleGroup.Id), nameof(MuscleGroup.Name));
            return View(viewModel);
        }

        // POST: Muscles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MuscleCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _bll.Muscles.Add(viewModel.Muscle);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var muscleGroups = await _bll.MuscleGroups.AllAsync();
            viewModel.MuscleGroupSelectList = new SelectList(muscleGroups, nameof(
                MuscleGroup.Id), nameof(MuscleGroup.Name));
            return View(viewModel);
        }

        // GET: Muscles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var viewModel = new MuscleCreateEditViewModel
            {
                Muscle = await _bll.Muscles.FindAsync((Guid) id),
                MuscleGroupSelectList = new SelectList(
                    await _bll.MuscleGroups.AllAsync(), 
                    nameof(MuscleGroup.Id), 
                    nameof(MuscleGroup.Name))
            };
            if (viewModel.Muscle == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: Muscles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MuscleCreateEditViewModel viewModel)
        {
            if (id != viewModel.Muscle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Muscles.Update(viewModel.Muscle);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.MuscleGroupSelectList = new SelectList(
                await _bll.MuscleGroups.AllAsync(),
                nameof(MuscleGroup.Id),
                nameof(MuscleGroup.Name));
            
            return View(viewModel);
        }

        // GET: Muscles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscle = await _bll.Muscles.FindAsync((Guid) id);
            if (muscle == null)
            {
                return NotFound();
            }

            return View(muscle);
        }

        // POST: Muscles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var muscle = await _bll.Muscles.FindAsync(id);
            _bll.Muscles.Remove(muscle);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
