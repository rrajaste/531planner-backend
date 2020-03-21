using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser : IdentityUser
    {
        public string PerformedExerciseId { get; set; }
        public string WorkoutRoutineId { get; set; }
        public string BodyMeasurementsId { get; set; }
        public string DailyNutritionIntakeId { get; set; }
        
        public ICollection<PerformedExercise>? PerformedExercises { get; set; }
        public ICollection<WorkoutRoutine>? WorkoutRoutines { get; set; }
        public ICollection<BodyMeasurements>? BodyMeasurements { get; set; }
        public ICollection<DailyNutritionIntake>? DailyNutritionIntakes { get; set; }
    }
}