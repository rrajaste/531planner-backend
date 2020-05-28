using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class AppUsersViewModel
    {
        [MinLength(4)]
        [MaxLength(64)]
        [Display(Name = nameof(Resources.ViewModels.AppUsersViewModel.UserName), 
            ResourceType = typeof(Resources.ViewModels.AppUsersViewModel))]
        public string UserName { get; set; }
        [EmailAddress]
        [Display(Name = nameof(Resources.ViewModels.AppUsersViewModel.Email), 
            ResourceType = typeof(Resources.ViewModels.AppUsersViewModel))]
        public string Email { get; set; }
        
        public string Roles { get; set; }
        
        [Display(Name = nameof(Resources.ViewModels.AppUsersViewModel.IsLocked), 
            ResourceType = typeof(Resources.ViewModels.AppUsersViewModel))]
        public bool IsLocked { get; set; }
    }
}