using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class AppUserSearchViewModel
    {
        [MinLength(2), MaxLength(1024)]
        public string SearchString { get; set; }
        public List<string> SelectedRoles { get; set; }
        public MultiSelectList? Roles { get; set; }
    }
}