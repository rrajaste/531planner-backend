using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.raraja.Contracts.Domain;
using ee.itcollege.raraja.Domain;

namespace Domain.App
{
    public class TrainingWeek : TrainingWeek<Guid>, IDomainEntityIdMetadata
    {
    }

    public class TrainingWeek<TKey> : DomainEntityIdMetadata<TKey>
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