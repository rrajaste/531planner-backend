using System;
using Contracts.DAL.Base;
using Domain.App.Enums;

namespace DAL.App.DTO
{
    public class TargetMuscleGroup : TargetMuscleGroup<Guid>, IDALBaseDTO
    {
    }

    public class TargetMuscleGroup<TKey> : IDALBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public TKey MuscleGroupId { get; set; } = default!;
        public TKey ExerciseId { get; set; } = default!;
        public MuscleGroup? MuscleGroup { get; set; }
        public TargetMuscleGroupIntensity Intensity { get; set; }
    }
}