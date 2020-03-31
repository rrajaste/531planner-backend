using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class Exercise : DomainEntity
    {
        [MaxLength(255)] public string Name { get; set; } = default!;
        [MaxLength(255)] 
        public string Description { get; set; } = default!;
        public Guid ExerciseTypeId { get; set; }
        public ExerciseType? ExerciseType { get; set; }
        public ICollection<TargetMuscleGroup>? TargetMuscleGroups { get; set; }
        public ICollection<ExerciseInTrainingDay>? ExerciseInTrainingDays { get; set; }
    }
}