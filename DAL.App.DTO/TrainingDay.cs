using System;
using System.Collections.Generic;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class TrainingDay : TrainingDay<Guid>, IDALBaseDTO
    {
    }

    public class TrainingDay<TKey> : IDALBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public DateTime Date { get; set; }
        public TKey TrainingWeekId { get; set; } = default!;
        public TKey TrainingDayTypeId { get; set; } = default!;
        public TrainingWeek? TrainingWeek { get; set; }
        public TrainingDayType? TrainingDayType { get; set; }
        public IEnumerable<ExerciseInTrainingDay>? ExercisesInTrainingDay { get; set; }
        public TKey Id { get; set; } = default!;
    }
}