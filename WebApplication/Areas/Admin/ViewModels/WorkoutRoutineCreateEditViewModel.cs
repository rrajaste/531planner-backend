using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkoutRoutine = BLL.App.DTO.WorkoutRoutine;

namespace WebApplication.ViewModels
{
    public class WorkoutRoutineCreateEditViewModel
    {
        public WorkoutRoutine WorkoutRoutine { get; set; }
        public WorkoutRoutineTranslation EstonianTranslation { get; set; }
        public WorkoutRoutineTranslation EnglishTranslation { get; set; }
        public SelectList? RoutineTypeSelectList { get; set; }
    }
}