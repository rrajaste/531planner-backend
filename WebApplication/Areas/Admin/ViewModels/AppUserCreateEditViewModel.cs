using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Domain.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class AppUserCreateEditViewModel
    {
        [MinLength(4)]
        [MaxLength(64)]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType("password")]
        [MinLength(8)]
        public string Password { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public IEnumerable<string> SelectedRoles { get; set; }
        
        public MultiSelectList? Roles { get; set; }
    }
}