using System.ComponentModel.DataAnnotations;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class AppUserSearchViewModel
    {
        [MinLength(2), MaxLength(1024)]
        public string? search { get; set; }
        public bool includeDeactivated { get; set; }
    }
}