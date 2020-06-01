using System.Collections.Generic;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class AppUsersIndexViewModel
    {
        public IEnumerable<AppUsersViewModel> AppUsers { get; set; } = default!;
        public AppUserSearchViewModel SearchViewModel { get; set; } = default!;
    }
}