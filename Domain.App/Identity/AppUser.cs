using System;
using System.Collections.Generic;
using Contracts.Domain;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity
{
    public class AppUser : AppUser<Guid>
    {
    }

    public class AppUser<TKey> : IdentityUser<TKey>, IDomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public ICollection<WorkoutRoutine>? WorkoutRoutines { get; set; }
        public ICollection<BodyMeasurement>? BodyMeasurements { get; set; }
        public ICollection<DailyNutritionIntake>? DailyNutritionIntakes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ClosedAt { get; set; } = DateTime.MaxValue;
        public string? Comment { get; set; }
    }
}