using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class ExerciseCreateEditViewModel
    {
        public Exercise Exercise { get; set; } = default!;
        public SelectList? ExerciseTypeSelectList { get; set; }
    }
}