using System;
using System.Collections.Generic;
using DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser : IdentityUser
    {
        public ICollection<PerformedExercise>? PerformedExercises { get; set; }
        public ICollection<WorkoutRoutine>? WorkoutRoutines { get; set; }
        public ICollection<BodyMeasurements>? BodyMeasurements { get; set; }
        public ICollection<DailyNutritionIntake>? DailyNutritionIntakes { get; set; }
    }
}