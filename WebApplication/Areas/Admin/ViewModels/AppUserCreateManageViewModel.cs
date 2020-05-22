using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Domain.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class AppUserCreateManageViewModel
    {
        [MinLength(4)]
        [MaxLength(256)]
        public string UserName { get; set; }
        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }
        [DataType("password")]
        [MinLength(8)]
        [MaxLength(256)]
        public string Password { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public IEnumerable<string> SelectedRoles { get; set; }
        public MultiSelectList? Roles { get; set; }
    }
}