using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class ExerciseInTrainingDayCreateEditViewModel
    {
        public ExerciseInTrainingDay ExerciseInTrainingDay { get; set; } = default!;
        public SelectList? Exercises { get; set; }
        public SelectList? ExerciseTypes { get; set; }
    }
}