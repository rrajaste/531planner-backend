using System;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class TargetMuscleGroup : DomainEntity
    {
        [MaxLength(255)]
        public string Name { get; set; } = default!;
        [MaxLength(255)]
        public string Description { get; set; } = default!;
        public string MuscleGroupId { get; set; }
        public string ExerciseId { get; set; }
        public MuscleGroup? MuscleGroup { get; set; }
        public Exercise? Exercise { get; set; }
    }
}