using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class WorkoutRoutineInfo : WorkoutRoutineInfo<Guid>
    {
    }
    
    
    public class WorkoutRoutineInfo<TKey> : DomainEntityIdMetadata<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey WorkoutRoutineId { get; set; } = default!;
        public WorkoutRoutine? WorkoutRoutine { get; set; }

        [MaxLength(255)]
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.Domain.WorkoutRoutine))]
        public string Name { get; set; } = default!;
        
        
        [MaxLength(1024)]
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.WorkoutRoutine))]
        public string Description { get; set; } = default!;

        public string CultureCode { get; set; } = default!;
    }
}