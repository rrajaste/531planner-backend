using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkoutRoutine = BLL.App.DTO.WorkoutRoutine;

namespace WebApplication.ViewModels
{
    public class WorkoutRoutineCreateEditViewModel
    {
        public WorkoutRoutine WorkoutRoutine { get; set; } = default!;
        public WorkoutRoutineTranslation EstonianTranslation { get; set; } = default!;
        public WorkoutRoutineTranslation EnglishTranslation { get; set; } = default!;
        public SelectList? RoutineTypeSelectList { get; set; }
    }
}