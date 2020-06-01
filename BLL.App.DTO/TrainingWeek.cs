using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class TrainingWeek : TrainingWeek<Guid>, IBLLBaseDTO
    {
    }

    public class TrainingWeek<TKey> : IBLLBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public int WeekNumber { get; set; }

        [Display(Name = nameof(IsDeload), ResourceType = typeof(Resources.BLL.TrainingWeek))]
        public bool IsDeload { get; set; }

        public DateTime StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }

        public TKey TrainingCycleId { get; set; } = default!;
        public TrainingCycle? TrainingCycle { get; set; }
        public IEnumerable<UserTrainingDay>? TrainingDays { get; set; }
        public TKey Id { get; set; } = default!;
    }
}