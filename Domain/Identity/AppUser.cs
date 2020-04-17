using System;
using System.Collections.Generic;
using Contracts.DAL.Base;
using DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser : AppUser<Guid>
    {
    }

    public class AppUser<TKey> : IdentityUser<TKey>, IDomainEntityBaseMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public ICollection<PersonalRecord>? PersonalRecords { get; set; } 
        public ICollection<WorkoutRoutine>? WorkoutRoutines { get; set; }
        public ICollection<BodyMeasurement>? BodyMeasurements { get; set; }
        public ICollection<DailyNutritionIntake>? DailyNutritionIntakes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ClosedAt { get; set; } = DateTime.MaxValue;
        public string? Comment { get; set; }
    }
}