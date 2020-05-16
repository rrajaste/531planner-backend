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

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var viewModels = users.Select(u => new AppUserIndexViewModel()
            {
                UserName = u.UserName,
                Email = u.Email,
                Roles = string.Join(", ", _userManager.GetRolesAsync(u).Result),
                IsLocked = u.LockoutEnd
            });
            return View(viewModels);
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
        public IActionResult Create()
        {
            var appRoles = _roleManager.Roles.Select(r => r.Name);
            var viewModel = new AppUserCreateEditViewModel()
            {
                Roles = new MultiSelectList(appRoles)
            };
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppUserCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid && IsEmailValid(viewModel.Email))
            {
                var user = new AppUser()
                {
                    UserName = viewModel.UserName,
                    Email = viewModel.Email
                };
                var userAddResult = await _userManager.CreateAsync(user, viewModel.Password);
                var userInUserManager = await _userManager.FindByEmailAsync(user.Email);
                var rolesAddResult = await _userManager.AddToRolesAsync(userInUserManager, viewModel.SelectedRoles);
                if (rolesAddResult.Succeeded && userAddResult.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            var roles = _roleManager.Roles.Select(r => r.Name);
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
        //     if (! IsEmailValid(email))
        //     {
        //         return BadRequest();
        //     }
        //
        //     _userManager.ChangeEmailAsync();
        // }
        
        [HttpPost]
        public async Task<IActionResult> LockUser(string userName)
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
            var result = await _userManager.SetLockoutEnabledAsync(appUser, true);
            if (!result.Succeeded)
            {
                return StatusCode(403);
            }
            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        public async Task<IActionResult> UnLockUser(string userName)
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
            var result = await _userManager.SetLockoutEnabledAsync(appUser, false);
            if (!result.Succeeded)
            {
                return StatusCode(403);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool IsEmailValid(string email)
        {
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch {
                return false;
            }
        }
    }
}
