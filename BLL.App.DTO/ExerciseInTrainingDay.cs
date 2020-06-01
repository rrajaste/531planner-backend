using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class ExerciseInTrainingDay : ExerciseInTrainingDay<Guid>, IBLLBaseDTO
    {
    }

    public class ExerciseInTrainingDay<TKey> : IBLLBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey ExerciseId { get; set; } = default!;

        [Display(Name = nameof(Exercise), ResourceType = typeof(Resources.BLL.ExerciseInTrainingDay))]
        public Exercise? Exercise { get; set; }

        public TKey TrainingDayId { get; set; } = default!;
        public TrainingDay? TrainingDay { get; set; }
        public TKey ExerciseTypeId { get; set; } = default!;

        [Display(Name = nameof(ExerciseType), ResourceType = typeof(Resources.BLL.ExerciseInTrainingDay))]
        public ExerciseType? ExerciseType { get; set; }

        public IEnumerable<ExerciseSet>? WarmUpSets { get; set; }
        public IEnumerable<ExerciseSet>? WorkSets { get; set; }
        public TKey Id { get; set; } = default!;
    }
}