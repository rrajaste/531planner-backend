using System;
using System.Collections.Generic;
using Contracts.DAL.App;

namespace DAL.App.DTO
{
    public class TrainingWeek : TrainingWeek<Guid>, IDALBaseDTO
    {
    }

    public class TrainingWeek<TKey> : IDALBaseDTO<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public int WeekNumber { get; set; }
        public bool IsDeload { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }

        public TKey TrainingCycleId { get; set; } = default!;
        public TrainingCycle? TrainingCycle { get; set; }
        public ICollection<TrainingDay>? TrainingDays { get; set; }
    }
}