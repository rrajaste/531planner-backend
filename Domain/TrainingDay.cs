using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class TrainingDay : DomainEntity
    {
        public DateTime Date { get; set; }
        public Guid TrainingWeekId { get; set; } = default!;
        public Guid TrainingDayTypeId { get; set; } = default!;
        public TrainingWeek? TrainingWeek { get; set; }
        public TrainingDayType? TrainingDayType { get; set; }
        public ICollection<ExerciseSet>? ExerciseSets { get; set; }
    }
}