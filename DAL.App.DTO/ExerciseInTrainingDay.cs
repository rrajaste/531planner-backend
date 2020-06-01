using System;
using System.Collections.Generic;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class ExerciseInTrainingDay : ExerciseInTrainingDay<Guid>, IDALBaseDTO
    {
    }

    public class ExerciseInTrainingDay<TKey> : IDALBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey ExerciseId { get; set; } = default!;
        public Exercise? Exercise { get; set; }
        public TKey TrainingDayId { get; set; } = default!;
        public TrainingDay? TrainingDay { get; set; }
        public TKey ExerciseTypeId { get; set; } = default!;
        public ExerciseType? ExerciseType { get; set; }
        public IEnumerable<ExerciseSet>? ExerciseSets { get; set; }
        public TKey Id { get; set; } = default!;
    }
}