using System;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class TargetMuscleGroup : TargetMuscleGroup<Guid>, IBLLBaseDTO
    {
    }

    public class TargetMuscleGroup<TKey> : IBLLBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public TKey MuscleGroupId { get; set; } = default!;
        public TKey ExerciseId { get; set; } = default!;
        public MuscleGroup? MuscleGroup { get; set; }
    }
}