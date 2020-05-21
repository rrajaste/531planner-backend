using System;
using System.Collections.Generic;
using BLL.App.DTO;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class TrainingDayViewModel
    {
        public BaseTrainingDay TrainingDay { get; set; }
        public Guid WorkoutRoutineId { get; set; }
    }
}