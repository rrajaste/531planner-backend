using System;
using System.Collections.Generic;
using Contracts.DAL.App;

namespace DAL.App.DTO
{
    public class TrainingDay : TrainingDay<Guid>, IDALBaseDTO
    {
    }

    public class TrainingDay<TKey> : IDALBaseDTO<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public DateTime Date { get; set; } = default!;
        public TKey TrainingWeekId { get; set; } = default!;
        public TKey TrainingDayTypeId { get; set; } = default!;
        public TrainingWeek? TrainingWeek { get; set; }
        public TrainingDayType? TrainingDayType { get; set; }
        public ICollection<ExerciseSet>? ExerciseSets { get; set; }
    }
}