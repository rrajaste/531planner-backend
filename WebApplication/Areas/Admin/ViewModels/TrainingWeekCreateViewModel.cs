using System;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class TrainingWeekCreateViewModel
    {
        public Guid WorkoutRoutineId { get; set; }
        public bool IsDeload { get; set; }
    }
}