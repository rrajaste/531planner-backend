using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class TrainingDay : TrainingDay<Guid>, IDomainEntityBaseMetadata
    {
    }

    public class TrainingDay<TKey> : DomainEntityBaseMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        [Display(Name = nameof(Date), ResourceType = typeof(Resources.Domain.TrainingDay))]
        public DateTime Date { get; set; } = default!;
        public TKey TrainingWeekId { get; set; } = default!;
        public TKey TrainingDayTypeId { get; set; } = default!;
        public TrainingWeek? TrainingWeek { get; set; }
        public TrainingDayType? TrainingDayType { get; set; }
        public ICollection<ExerciseSet>? ExerciseSets { get; set; }
    }
}