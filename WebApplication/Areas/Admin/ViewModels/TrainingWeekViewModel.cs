using System;
using BLL.App.DTO;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class TrainingWeekViewModel
    {
        public Guid WorkoutRoutineId { get; set; }
        public TrainingWeek TrainingWeek { get; set; }

    }
}