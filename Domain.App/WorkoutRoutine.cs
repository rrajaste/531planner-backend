using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.raraja.Contracts.Domain;
using Domain.App.Identity;
using ee.itcollege.raraja.Domain;

namespace Domain.App
{
    public class WorkoutRoutine : WorkoutRoutine<Guid>, IDomainEntityIdMetadata
    {
    }

    public class WorkoutRoutine<TKey> : DomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {

        public bool IsBaseRoutine { get; set; } = false;
        public TKey RoutineTypeId { get; set; } = default!;
        public TKey? AppUserId { get; set; }
        public AppUser? User { get; set; }
        
        public ICollection<ExerciseSet>? ExerciseSets { get; set; }
        
        [Display(Name = nameof(RoutineType), ResourceType = typeof(Resources.Domain.WorkoutRoutine))]
        public RoutineType? RoutineType { get; set; }

        [Display(Name = nameof(TrainingCycles), ResourceType = typeof(Resources.Domain.WorkoutRoutine))]
        public ICollection<TrainingCycle>? TrainingCycles { get; set; }
        
        public ICollection<WorkoutRoutineInfo>? WorkoutRoutineInfos { get; set; }
    }
}