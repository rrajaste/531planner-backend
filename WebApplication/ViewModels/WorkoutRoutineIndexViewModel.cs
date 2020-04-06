using System.Collections;
using System.Collections.Generic;
using Domain;

namespace WebApplication.ViewModels
{
    public class WorkoutRoutineIndexViewModel
    {
        public WorkoutRoutine? ActiveRoutine { get; set; }
        public IEnumerable<WorkoutRoutine>? PreviousRoutines { get; set; }
    }
}