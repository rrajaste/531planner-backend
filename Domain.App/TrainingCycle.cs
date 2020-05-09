using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain;
using Domain.Base;

namespace Domain.App
{
    public class TrainingCycle : TrainingCycle<Guid>, IDomainEntityIdMetadata
    {
    }

    public class TrainingCycle<TKey> : DomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        [Display(Name = nameof(CycleNumber), ResourceType = typeof(Resources.Domain.TrainingCycle))]
        public int CycleNumber { get; set; }

        [Display(Name = nameof(StartingDate), ResourceType = typeof(Resources.Domain.TrainingCycle))]

        public DateTime StartingDate { get; set; }

        [Display(Name = nameof(EndingDate), ResourceType = typeof(Resources.Domain.TrainingCycle))]
        public DateTime? EndingDate { get; set; }

        [Display(Name = nameof(WorkoutRoutine), ResourceType = typeof(Resources.Domain.TrainingCycle))]

        public WorkoutRoutine? WorkoutRoutine { get; set; }

        public TKey WorkoutRoutineId { get; set; }

        public ICollection<TrainingWeek>? TrainingWeeks { get; set; }
    }
}