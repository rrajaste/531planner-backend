using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Domain.App.Constants;
using Domain.App.Identity;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Areas.Admin.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Route("Admin/AppUsers/{action=index}/{username?}")]
    [Authorize(Roles = AppRoles.Administrator)]
    public class AppUsersController : Controller
    {
        private readonly RoleManager<AppUserRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AppUsersController(UserManager<AppUser> userManager, RoleManager<AppUserRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(string? search, bool? includeDeactivated)
        {
            search = search?.ToUpper();
            var query = _userManager.Users.Where(user =>
                (search == null || user.NormalizedUserName.Contains(search) || user.NormalizedEmail.Contains(search))
                && (includeDeactivated == true || !user.AccountLocked));

            var foundUsers = await query.OrderBy(user => user.CreatedAt).Take(25).ToListAsync();

            var searchViewModel = new AppUserSearchViewModel
            {
                search = search ?? "",
                includeDeactivated = includeDeactivated ?? false
            };
            var userViewModels = foundUsers.Select(user => new AppUsersViewModel
            {
                Email = user.Email,
                UserName = user.UserName,
                IsLocked = user.AccountLocked
            });
            var viewModel = new AppUsersIndexViewModel
            {
                AppUsers = userViewModels,
                SearchViewModel = searchViewModel
            };

            return View(viewModel);
        }

        // GET: Admin/Users/Details/5
        public async Task<IActionResult> Details(string? userName)
        {
            if (userName == null) return NotFound();

            var appUser = await _userManager.FindByNameAsync(userName);
            if (appUser == null) return NotFound();
            var viewModel = new AppUserDetailsViewModel
            {
                CreatedAt = appUser.CreatedAt,
                Email = appUser.Email,
                EmailConfirmed = appUser.EmailConfirmed,
                LockoutEnabled = appUser.LockoutEnabled,
                PhoneNumber = appUser.PhoneNumber ?? "Unknown",
                PhoneNumberConfirmed = appUser.PhoneNumberConfirmed,
                UserName = appUser.UserName
            };
            return View(viewModel);
        }

        // GET: Admin/Users/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new AppUserCreateManageViewModel
            {
                UserName = "",
                Password = "",
                Roles = await GetRolesSelectListAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppUserCreateManageViewModel createViewModel)
        {
            if (!await IsUserNameValidAsync(createViewModel.UserName))
                ModelState.AddModelError("", "This username is already in use!");
            if (!await IsEmailValidAsync(createViewModel.Email))
                ModelState.AddModelError("", "This email is already in use!");

            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = createViewModel.UserName,
                    Email = createViewModel.Email
                };
                var userAddResult = await _userManager.CreateAsync(user, createViewModel.Password);
                if (userAddResult == IdentityResult.Success)
                {
                    var userInUserManager = await _userManager.FindByEmailAsync(user.Email);
                    var rolesAddResult =
                        await _userManager.AddToRolesAsync(userInUserManager, createViewModel.SelectedRoles);
                    if (rolesAddResult.Succeeded && userAddResult.Succeeded) return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "User creation failed");
                }
            }

            createViewModel.Roles = await GetRolesSelectListAsync();
            return View(createViewModel);
        }

        public async Task<IActionResult> ManageUser(string? userName)
        {
            if (userName == null) return NotFound();

            var appUser = await _userManager.FindByNameAsync(userName);

            if (appUser == null) return NotFound();

            var viewModel = new AppUserCreateManageViewModel
            {
                Email = appUser.Email,
                UserName = appUser.UserName,
                SelectedRoles = await _userManager.GetRolesAsync(appUser),
                Roles = await GetRolesSelectListAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUser(AppUserCreateManageViewModel viewModel)
        {
            if (viewModel.UserName == null) return NotFound();
            var appUser = await _userManager.FindByNameAsync(viewModel.UserName);

            if (appUser == null) return NotFound();

            await _userManager.RemoveFromRolesAsync(appUser, AppRoles.AllRoles);

            if (!viewModel.SelectedRoles.IsEmptyOrNull())
            {
                var rolesAddResult = await _userManager.AddToRolesAsync(appUser, viewModel.SelectedRoles);
                if (rolesAddResult.Succeeded) return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> LockUser(string userName, string returnUrl)
        {
            if (string.IsNullOrEmpty(userName)) return BadRequest();
            var appUser = await _userManager.FindByNameAsync(userName);
            if (appUser == null) return BadRequest();
            await _userManager.SetLockoutEnabledAsync(appUser, true);

            await _userManager.SetLockoutEndDateAsync(appUser, DateTime.Today.AddYears(500));
            appUser.AccountLocked = true;
            await _userManager.UpdateAsync(appUser);
            return LocalRedirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> UnLockUser(string userName, string returnUrl)
        {
            if (string.IsNullOrEmpty(userName)) return BadRequest();

            var appUser = await _userManager.FindByNameAsync(userName);
            if (appUser == null) return BadRequest();
            await _userManager.SetLockoutEnabledAsync(appUser, false);
            appUser.AccountLocked = false;
            await _userManager.UpdateAsync(appUser);
            return LocalRedirect(returnUrl);
        }

        [HttpPost]
        public IActionResult Search(AppUserSearchViewModel viewModel)
        {
            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index),
                    new {Search = viewModel.search, IncludeDeactivated = viewModel.includeDeactivated});
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> IsEmailValidAsync(string email)
        {
            var userWithEmail =
                await _userManager.Users.FirstOrDefaultAsync(user => user.NormalizedEmail.Equals(email.ToUpper()));
            if (userWithEmail != null) return false;
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> IsUserNameValidAsync(string username)
        {
            var userWithUsername =
                await _userManager.Users.FirstOrDefaultAsync(user =>
                    user.NormalizedUserName.Equals(username.ToUpper()));
            return userWithUsername == null;
        }

        private async Task<MultiSelectList> GetRolesSelectListAsync()
        {
            var appRoles = await _roleManager.Roles.ToListAsync();

            return new MultiSelectList(
                appRoles, nameof(AppUserRole.Name), nameof(AppUserRole.DisplayName));
        }
    }
}