using System;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class TargetMuscleGroup : TargetMuscleGroup<Guid>, IDALBaseDTO
    {
    }

    public class TargetMuscleGroup<TKey> : IDALBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public TKey MuscleGroupId { get; set; } = default!;
        public TKey ExerciseId { get; set; } = default!;
        public MuscleGroup? MuscleGroup { get; set; }
        public Exercise? Exercise { get; set; }
    }
}