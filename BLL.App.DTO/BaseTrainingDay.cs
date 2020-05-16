using System;
using System.Collections.Generic;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class BaseTrainingDay : BaseTrainingDay<Guid>, IBLLBaseDTO
    {
    }

    public class BaseTrainingDay<TKey> : IBLLBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public DayOfWeek DayOfWeek { get; set; }
        public TKey TrainingWeekId { get; set; } = default!;
        public TKey TrainingDayTypeId { get; set; } = default!;
        public TrainingWeek? TrainingWeek { get; set; }
        public TrainingDayType? TrainingDayType { get; set; }
        public IEnumerable<ExerciseSet>? ExerciseSets { get; set; }
    }
}