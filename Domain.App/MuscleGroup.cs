using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain;
using Domain.Base;

namespace Domain.App
{

    public class MuscleGroup : MuscleGroup<Guid>, IDomainEntityIdMetadata
    {
    }

    public class MuscleGroup<TKey> : DomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        [MaxLength(255)]
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.Domain.MuscleGroup))]
        public string Name { get; set; } = default!;
        [MaxLength(10240)]
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.MuscleGroup))]
        public string Description { get; set; } = default!;
        
        public ICollection<TargetMuscleGroup>? TargetMuscleGroups { get; set; }
        
        public ICollection<Muscle>? Muscles { get; set; }
    }
}