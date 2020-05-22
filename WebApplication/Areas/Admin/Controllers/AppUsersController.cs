using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.App.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Areas.Admin.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class AppUsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppUserRole> _roleManager;

        public AppUsersController(UserManager<AppUser> userManager, RoleManager<AppUserRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(string? search, bool? includeDeactivated)
        {
            search = search?.ToUpper();
            var query = _userManager.Users.Where(user => 
                    (search == null || (user.NormalizedUserName.Contains(search) || user.NormalizedEmail.Contains(search))) 
                    && (includeDeactivated == true || !user.AccountLocked));
           
            var foundUsers = await query.OrderBy(user => user.CreatedAt).Take(25).ToListAsync();
            
            var searchViewModel = new AppUserSearchViewModel()
            {
                search = search ?? "",
                includeDeactivated = includeDeactivated ?? false
            };
            var userViewModels = foundUsers.Select(user => new AppUsersViewModel()
            {
                Email = user.Email,
                UserName = user.UserName,
                IsLocked = user.AccountLocked,
            });
            var viewModel = new AppUsersIndexViewModel()
            {
                AppUsers = userViewModels,
                SearchViewModel = searchViewModel
            };
            
            return View(viewModel);
        }

        // GET: Admin/Users/Details/5
        public async Task<IActionResult> Details(string? userName)
        {
            if (userName == null)
            {
                return NotFound();
            }

            var appUser = await _userManager.FindByNameAsync(userName);
            if (appUser == null)
            {
                return NotFound();
            }
            var viewModel = new AppUserDetailsViewModel()
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
            var appRoles = await _roleManager.Roles.ToListAsync();
            var viewModel = new AppUserCreateEditViewModel()
            {
                UserName = "",
                Password = "",
                Roles = new MultiSelectList(appRoles, nameof(AppUserRole.Name), nameof(AppUserRole.DisplayName))
            };
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppUserCreateEditViewModel viewModel)
        {
            if (! await IsUserNameValidAsync(viewModel.UserName))
            {
                ModelState.AddModelError("", "This username is already in use!");
            }
            if (! await IsEmailValidAsync(viewModel.Email))
            {
                ModelState.AddModelError("", "This email is already in use!");
            }
            
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    UserName = viewModel.UserName,
                    Email = viewModel.Email
                };
                var userAddResult = await _userManager.CreateAsync(user, viewModel.Password);
                if (userAddResult == IdentityResult.Success)
                {
                    var userInUserManager = await _userManager.FindByEmailAsync(user.Email);
                    var rolesAddResult = await _userManager.AddToRolesAsync(userInUserManager, viewModel.SelectedRoles);
                    if (rolesAddResult.Succeeded && userAddResult.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }   
                }
                else
                {
                    ModelState.AddModelError("", "User creation failed");
                }
            }
            var roles = _roleManager.Roles.Select(r => r.DisplayName);
            viewModel.Roles = new SelectList(roles);
            return View(viewModel);
        }

        public async Task<IActionResult> ManageUser(string? userName)
        {
            if (userName == null)
            {
                return NotFound();
            }

            var appUser = await _userManager.FindByNameAsync(userName);
            
            if (appUser == null)
            {
                return NotFound();
            }
            
            var viewModel = new AppUserCreateEditViewModel()
            {
                Email = appUser.Email,
                UserName = appUser.UserName,
                SelectedRoles = await _userManager.GetRolesAsync(appUser)
            };
            return View(viewModel);
        }
        
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> ChangeEmail(string userName, string email)
        // {
        //     var user = await _userManager.FindByNameAsync(userName);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }
        //     if (! await IsEmailValid(email))
        //     {
        //         return BadRequest();
        //     }
        //
        //     _userManager.ChangeEmailAsync();
        // }
        [HttpPost]
        public async Task<IActionResult> LockUser(string userName, string returnUrl)
        {
            
            if (string.IsNullOrEmpty(userName))
            {
                return BadRequest();
            }
            var appUser = await _userManager.FindByNameAsync(userName);
            if (appUser == null)
            {
                return BadRequest();
            }
            await _userManager.SetLockoutEnabledAsync(appUser, true);
            
            await _userManager.SetLockoutEndDateAsync(appUser, DateTime.Today.AddYears(500));
            appUser.AccountLocked = true;
            await _userManager.UpdateAsync(appUser);
            return LocalRedirect(returnUrl);
        }
        
        [HttpPost]
        public async Task<IActionResult> UnLockUser(string userName, string returnUrl)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return BadRequest();
            }

            var appUser = await _userManager.FindByNameAsync(userName);
            if (appUser == null)
            {
                return BadRequest();
            }
            await _userManager.SetLockoutEnabledAsync(appUser, false);
            appUser.AccountLocked = false;
            await _userManager.UpdateAsync(appUser);
            return LocalRedirect(returnUrl);
        }

        [HttpPost]
        public IActionResult Search(AppUserSearchViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index),
                    new {Search = viewModel.search, IncludeDeactivated = viewModel.includeDeactivated});
            }
            return RedirectToAction(nameof(Index));
        }
        
        private async Task<bool> IsEmailValidAsync(string email)
        {
            var userWithEmail =
                await _userManager.Users.FirstOrDefaultAsync(user => user.NormalizedEmail.Equals(email.ToUpper()));
            if (userWithEmail != null)
            {
                return false;
            }
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch {
                return false;
            }
        }
        
        private async Task<bool> IsUserNameValidAsync(string username)
        {
            var userWithUsername =
                await _userManager.Users.FirstOrDefaultAsync(user => user.NormalizedUserName.Equals(username.ToUpper()));
            return userWithUsername == null;
        }
    }
}
