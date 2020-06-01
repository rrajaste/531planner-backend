using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.raraja.Contracts.Domain;
using Domain.Base;

namespace Domain.App
{
    public class TrainingDay : TrainingDay<Guid>, IDomainEntityIdMetadata
    {
    }

    public class TrainingDay<TKey> : DomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        [Display(Name = nameof(Date), ResourceType = typeof(Resources.Domain.TrainingDay))]
        public DateTime Date { get; set; } = default!;
        public TKey TrainingWeekId { get; set; } = default!;
        public TKey TrainingDayTypeId { get; set; } = default!;
        public TrainingWeek? TrainingWeek { get; set; }
        public TrainingDayType? TrainingDayType { get; set; }
        public ICollection<ExerciseInTrainingDay>? ExercisesInTrainingDay { get; set; }
    }
}