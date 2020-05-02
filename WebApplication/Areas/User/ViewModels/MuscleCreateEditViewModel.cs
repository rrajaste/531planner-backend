using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.ViewModels
{
    public class MuscleCreateEditViewModel
    {
        public Muscle Muscle { get; set; }
        public SelectList? MuscleGroupSelectList { get; set; }
    }
}