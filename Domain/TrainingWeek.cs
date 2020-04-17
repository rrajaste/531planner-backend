using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class TrainingWeek : TrainingWeek<Guid>, IDomainEntityBaseMetadata
    {
    }

    public class TrainingWeek<TKey> : DomainEntityBaseMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        [Display(Name = nameof(WeekNumber), ResourceType = typeof(Resources.Domain.TrainingWeek))]
        public int WeekNumber { get; set; }

        [Display(Name = nameof(IsDeload), ResourceType = typeof(Resources.Domain.TrainingWeek))]
        public bool IsDeload { get; set; }

        [Display(Name = nameof(StartingDate), ResourceType = typeof(Resources.Domain.TrainingWeek))]
        public DateTime StartingDate { get; set; }
        
        [Display(Name = nameof(EndingDate), ResourceType = typeof(Resources.Domain.TrainingWeek))]
        public DateTime? EndingDate { get; set; }

        public TKey TrainingCycleId { get; set; } = default!;
        
        [Display(Name = nameof(TrainingCycle), ResourceType = typeof(Resources.Domain.TrainingWeek))]
        public TrainingCycle? TrainingCycle { get; set; }
        public ICollection<TrainingDay>? TrainingDays { get; set; }
    }
}