using System;
using System.Collections.Generic;
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
        
        public string Roles { get; set; }
        public DateTimeOffset? IsLocked { get; set; }
    }
}