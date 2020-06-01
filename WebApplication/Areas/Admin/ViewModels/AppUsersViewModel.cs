using System.ComponentModel.DataAnnotations;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class AppUsersViewModel
    {
        [MinLength(4)]
        [MaxLength(64)]
        [Display(Name = nameof(Resources.ViewModels.AppUsersViewModel.UserName),
            ResourceType = typeof(Resources.ViewModels.AppUsersViewModel))]
        public string UserName { get; set; } = default!;

        [EmailAddress]
        [Display(Name = nameof(Resources.ViewModels.AppUsersViewModel.Email),
            ResourceType = typeof(Resources.ViewModels.AppUsersViewModel))]
        public string Email { get; set; } = default!;

        public string Roles { get; set; } = default!;

        [Display(Name = nameof(Resources.ViewModels.AppUsersViewModel.IsLocked),
            ResourceType = typeof(Resources.ViewModels.AppUsersViewModel))]
        public bool IsLocked { get; set; }
    }
}