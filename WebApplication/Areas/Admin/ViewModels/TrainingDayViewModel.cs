using System;
using BLL.App.DTO;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class TrainingDayViewModel
    {
        public BaseTrainingDay TrainingDay { get; set; } = default!;
        public Guid WorkoutRoutineId { get; set; }
    }
}