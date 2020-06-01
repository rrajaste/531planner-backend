using System;
using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class TrainingDayCreateEditViewModel
    {
        public BaseTrainingDay TrainingDay { get; set; } = default!;
        public Guid WorkoutRoutineId { get; set; } = default!;
        public SelectList? TrainingDayTypes { get; set; }
        public SelectList? DaysOfWeek { get; set; }
    }
}