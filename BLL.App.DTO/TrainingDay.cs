using System;
using System.Collections.Generic;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public abstract class TrainingDay : TrainingDay<Guid>, IBLLBaseDTO
    {
    }

    public abstract class TrainingDay<TKey> : IBLLBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public TKey TrainingWeekId { get; set; } = default!;
        public TKey TrainingDayTypeId { get; set; } = default!;
        public TrainingWeek? TrainingWeek { get; set; }
        public TrainingDayType? TrainingDayType { get; set; }
        public IEnumerable<ExerciseInTrainingDay>? MainLifts { get; set; }
        public IEnumerable<ExerciseInTrainingDay>? AccessoryLifts { get; set; }
    }
}