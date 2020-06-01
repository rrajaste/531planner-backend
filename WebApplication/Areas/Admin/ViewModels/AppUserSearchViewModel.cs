using System.ComponentModel.DataAnnotations;
using Resources.ViewModels;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class AppUserSearchViewModel
    {
        [Display(Name = nameof(AppUsersSearchViewModel.Search),
            ResourceType = typeof(AppUsersSearchViewModel))]
        [MinLength(2)]
        [MaxLength(1024)]
        public string? search { get; set; }

        [Display(Name = nameof(AppUsersSearchViewModel.IncludeDeactivated),
            ResourceType = typeof(AppUsersSearchViewModel))]
        public bool includeDeactivated { get; set; }
    }
}