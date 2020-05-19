using System;
using System.Collections.Generic;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class TrainingDay : TrainingDay<Guid>, IBLLBaseDTO
    {
    }

    public class TrainingDay<TKey> : IBLLBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public DateTime Date { get; set; }
        public TKey TrainingWeekId { get; set; } = default!;
        public TKey TrainingDayTypeId { get; set; } = default!;
        public TrainingWeek? TrainingWeek { get; set; }
        public TrainingDayType? TrainingDayType { get; set; }
        public IEnumerable<ExerciseInTrainingDay>? ExercisesInTrainingDay { get; set; }
    }
}