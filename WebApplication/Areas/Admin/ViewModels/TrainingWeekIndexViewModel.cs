using System.Collections.Generic;
using BLL.App.DTO;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class TrainingWeekIndexViewModel
    {
        public IEnumerable<TrainingWeek> TrainingWeeks { get; set; }
        public string WorkoutRoutineName { get; set; }
    }
}