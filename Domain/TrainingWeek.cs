using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class TrainingWeek : DomainEntity
    {
        public int TrainingWeekId { get; set; }
        public int WeekNumber { get; set; }
        public bool IsDeload { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public TrainingCycle? TrainingCycle { get; set; }
        public ICollection<TrainingDay>? TrainingDays { get; set; }
    }
}