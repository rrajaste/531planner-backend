using BLL.App.DTO;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class ExerciseInTrainingDayCreateEditViewModel
    {
        public ExerciseInTrainingDay ExerciseInTrainingDay { get; set; } = default!;
        public SelectList? Exercises { get; set; }
        public SelectList? ExerciseTypes { get; set; }
    }
}