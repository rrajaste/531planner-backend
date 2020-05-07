using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain;
using Domain.Base;

namespace Domain.App
{
    public class Exercise : Exercise<Guid>, IDomainEntityIdMetadata
    {
    }

    public class Exercise<TKey> : DomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        [MaxLength(255)] public string Name { get; set; } = default!;
        [MaxLength(255)] 
        public string Description { get; set; } = default!;

        public TKey ExerciseTypeId { get; set; } = default!;
        public ExerciseType? ExerciseType { get; set; }
        public ICollection<TargetMuscleGroup>? TargetMuscleGroups { get; set; }
    }
}