using System;
using System.Collections.Generic;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class TrainingWeek : TrainingWeek<Guid>, IBLLBaseDTO
    {
    }

    public class TrainingWeek<TKey> : IBLLBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public int WeekNumber { get; set; }
        public bool IsDeload { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }

        public TKey TrainingCycleId { get; set; } = default!;
        public TrainingCycle? TrainingCycle { get; set; }
        public IEnumerable<TrainingDay>? TrainingDays { get; set; }
    }
}