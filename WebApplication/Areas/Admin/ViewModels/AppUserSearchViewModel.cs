using System.ComponentModel.DataAnnotations;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class AppUserSearchViewModel
    {
        [Display(Name = nameof(Resources.ViewModels.AppUsersSearchViewModel.Search), 
            ResourceType = typeof(Resources.ViewModels.AppUsersSearchViewModel))]
        [MinLength(2), MaxLength(1024)]
        public string? search { get; set; }
        [Display(Name = nameof(Resources.ViewModels.AppUsersSearchViewModel.IncludeDeactivated), 
            ResourceType = typeof(Resources.ViewModels.AppUsersSearchViewModel))]
        public bool includeDeactivated { get; set; }
    }
}