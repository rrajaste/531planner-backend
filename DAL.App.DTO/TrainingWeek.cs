using System;
using System.Collections.Generic;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class TrainingWeek : TrainingWeek<Guid>, IDALBaseDTO
    {
    }

    public class TrainingWeek<TKey> : IDALBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public int WeekNumber { get; set; }
        public bool IsDeload { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }

        public TKey TrainingCycleId { get; set; } = default!;
        public TrainingCycle? TrainingCycle { get; set; }
        public ICollection<TrainingDay>? TrainingDays { get; set; }
    }
}