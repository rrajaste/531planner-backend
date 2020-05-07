using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain;
using Domain.Base;
using Domain.Identity;

namespace Domain.App
{
    public class WorkoutRoutine : WorkoutRoutine<Guid>, IDomainEntityIdMetadata
    {
    }

    public class WorkoutRoutine<TKey> : DomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    { 
        
        // TODO: Fix translations
        
        [MaxLength(255)]
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.Domain.WorkoutRoutine))]
        public string Name { get; set; } = default!;
        
        
        [MaxLength(255)]
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.WorkoutRoutine))]
        public string Description { get; set; } = default!;
        
        
        public bool IsBaseRoutine { get; set; } = default!;
        public TKey RoutineTypeId { get; set; } = default!;
        public TKey? AppUserId { get; set; }
        public AppUser? User { get; set; }
        
        public ICollection<ExerciseSet>? ExerciseSets { get; set; }
        
        [Display(Name = nameof(RoutineType), ResourceType = typeof(Resources.Domain.WorkoutRoutine))]
        public RoutineType? RoutineType { get; set; }
        public ICollection<PersonalRecord>? PersonalRecord { get; set; }
        
        
        [Display(Name = nameof(TrainingCycles), ResourceType = typeof(Resources.Domain.WorkoutRoutine))]
        public ICollection<TrainingCycle>? TrainingCycles { get; set; }
    }
}