using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class MuscleCreateEditViewModel
    {
        public Muscle Muscle { get; set; } = default!;
        public SelectList? MuscleGroupSelectList { get; set; }
    }
}