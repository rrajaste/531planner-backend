using System;
using System.Collections.Generic;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class ExerciseInTrainingDay : ExerciseInTrainingDay<Guid>, IBLLBaseDTO
    {
    }
    
    public class ExerciseInTrainingDay<TKey> : IBLLBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public TKey ExerciseId { get; set; } = default!;
        public Exercise? Exercise { get; set; }
        public TKey TrainingDayId { get; set; } = default!;
        public TrainingDay? TrainingDay { get; set; }
        public TKey ExerciseTypeId { get; set; } = default!;
        public ExerciseType? ExerciseType { get; set; }
        public IEnumerable<ExerciseSet>? ExerciseSets { get; set; }
    }
}