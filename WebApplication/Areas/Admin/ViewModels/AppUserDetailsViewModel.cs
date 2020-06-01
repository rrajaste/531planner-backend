using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class AppUserDetailsViewModel
    {
        [Display(Name = nameof(Resources.ViewModels.AppUserDetailsViewModel.CreatedAt), 
            ResourceType = typeof(Resources.ViewModels.AppUserDetailsViewModel))]
        public DateTime CreatedAt { get; set; }
        
        [Display(Name = nameof(Resources.ViewModels.AppUserDetailsViewModel.UserName), 
            ResourceType = typeof(Resources.ViewModels.AppUserDetailsViewModel))]
        public string UserName { get; set; } = default!;
        
        [Display(Name = nameof(Resources.ViewModels.AppUserDetailsViewModel.Email), 
            ResourceType = typeof(Resources.ViewModels.AppUserDetailsViewModel))]
        public string Email { get; set; } = default!;
        
        [Display(Name = nameof(Resources.ViewModels.AppUserDetailsViewModel.EmailConfirmed), 
            ResourceType = typeof(Resources.ViewModels.AppUserDetailsViewModel))]
        public bool EmailConfirmed { get; set; }
        
        [Display(Name = nameof(Resources.ViewModels.AppUserDetailsViewModel.PhoneNumber), 
            ResourceType = typeof(Resources.ViewModels.AppUserDetailsViewModel))]
        public string PhoneNumber { get; set; } = default!;
        
        [Display(Name = nameof(Resources.ViewModels.AppUserDetailsViewModel.PhoneNumberConfirmed), 
            ResourceType = typeof(Resources.ViewModels.AppUserDetailsViewModel))]
        public bool PhoneNumberConfirmed { get; set; }
        
        [Display(Name = nameof(Resources.ViewModels.AppUserDetailsViewModel.LockoutEnabled), 
            ResourceType = typeof(Resources.ViewModels.AppUserDetailsViewModel))]
        public bool LockoutEnabled { get; set; }
    }
}