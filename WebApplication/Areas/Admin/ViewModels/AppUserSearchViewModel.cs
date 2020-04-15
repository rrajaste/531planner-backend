using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class AppUserSearchViewModel
    {
        public string SearchString { get; set; }
        public IEnumerable<string> SelectedRoles { get; set; }
        public string IncludeInactive { get; set; }
        public MultiSelectList? Roles { get; set; }
    }
}