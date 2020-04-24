using System;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;
using Domain;

namespace Domain
{
    public class TargetMuscleGroup : TargetMuscleGroup<Guid>, IDomainEntityBaseMetadata
    {
    }

    public class TargetMuscleGroup<TKey> : DomainEntityBaseMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey MuscleGroupId { get; set; }
        public TKey ExerciseId { get; set; }
        public MuscleGroup? MuscleGroup { get; set; }
        public Exercise? Exercise { get; set; }
    }
}