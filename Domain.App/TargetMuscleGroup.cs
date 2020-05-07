using System;
using Contracts.Domain;
using Domain.Base;

namespace Domain.App
{
    public class TargetMuscleGroup : TargetMuscleGroup<Guid>, IDomainEntityIdMetadata
    {
    }

    public class TargetMuscleGroup<TKey> : DomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey MuscleGroupId { get; set; }
        public TKey ExerciseId { get; set; }
        public MuscleGroup? MuscleGroup { get; set; }
        public Exercise? Exercise { get; set; }
    }
}