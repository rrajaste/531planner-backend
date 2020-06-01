using System.Collections.Generic;
using BLL.App.DTO;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class WorkoutRoutineViewModel
    {
        public IEnumerable<WorkoutRoutine> PublishedRoutines { get; set; } = default!;
        public IEnumerable<WorkoutRoutine> UnPublishedRoutines { get; set; } = default!;
    }
}