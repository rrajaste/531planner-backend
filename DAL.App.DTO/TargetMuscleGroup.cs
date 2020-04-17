using System;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.App;
using DAL.Base;

namespace DAL.App.DTO
{
    public class TargetMuscleGroup : TargetMuscleGroup<Guid>, IDALBaseDTO
    {
    }

    public class TargetMuscleGroup<TKey> : IDALBaseDTO<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public TKey MuscleGroupId { get; set; }
        public TKey ExerciseId { get; set; }
        public MuscleGroup? MuscleGroup { get; set; }
        public Exercise? Exercise { get; set; }
    }
}