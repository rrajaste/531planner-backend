using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.ViewModels
{
    public class WorkoutRoutineCreateEditViewModel
    {
        public WorkoutRoutine WorkoutRoutine { get; set; }
        public SelectList? RoutineTypeSelectList { get; set; }
    }
}