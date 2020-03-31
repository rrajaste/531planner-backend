using System;
using System.Collections.Generic;
using DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser : AppUser<Guid>
    {
    }

    public class AppUser<TKey> : IdentityUser<TKey> 
        where TKey : IEquatable<TKey>
    {
        public ICollection<PersonalRecord>? PersonalRecords { get; set; } 
        public ICollection<WorkoutRoutine>? WorkoutRoutines { get; set; }
        public ICollection<BodyMeasurement>? BodyMeasurements { get; set; }
        public ICollection<DailyNutritionIntake>? DailyNutritionIntakes { get; set; }
    }
}