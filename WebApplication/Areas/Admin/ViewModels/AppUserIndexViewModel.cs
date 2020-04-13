using System.ComponentModel.DataAnnotations;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class AppUserIndexViewModel
    {
        [MinLength(4)]
        [MaxLength(64)]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}