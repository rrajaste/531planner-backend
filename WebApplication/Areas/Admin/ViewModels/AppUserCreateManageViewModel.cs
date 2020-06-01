using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class AppUserCreateManageViewModel
    {
        [MinLength(4)]
        [MaxLength(256)]
        [Display(Name = nameof(Resources.ViewModels.AppUserCreateManageViewModel.UserName),
            ResourceType = typeof(Resources.ViewModels.AppUserCreateManageViewModel))]
        public string UserName { get; set; } = default!;

        [EmailAddress]
        [MaxLength(256)]
        [Display(Name = nameof(Resources.ViewModels.AppUserCreateManageViewModel.Email),
            ResourceType = typeof(Resources.ViewModels.AppUserCreateManageViewModel))]
        public string Email { get; set; } = default!;

        [DataType("password")]
        [MinLength(8)]
        [MaxLength(256)]
        [Display(Name = nameof(Resources.ViewModels.AppUserCreateManageViewModel.Password),
            ResourceType = typeof(Resources.ViewModels.AppUserCreateManageViewModel))]
        public string Password { get; set; } = default!;

        [Display(Name = nameof(Resources.ViewModels.AppUserCreateManageViewModel.IsEmailConfirmed),
            ResourceType = typeof(Resources.ViewModels.AppUserCreateManageViewModel))]
        public bool IsEmailConfirmed { get; set; }

        public IEnumerable<string> SelectedRoles { get; set; } = default!;

        [Display(Name = nameof(Resources.ViewModels.AppUserCreateManageViewModel.Roles),
            ResourceType = typeof(Resources.ViewModels.AppUserCreateManageViewModel))]
        public MultiSelectList? Roles { get; set; }
    }
}