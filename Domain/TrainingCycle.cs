using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class TrainingCycle : DomainEntity
    {
        public int WorkoutRoutineId { get; set; }
        public int CycleNumber { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public WorkoutRoutine? WorkoutRoutine { get; set; }
        public ICollection<TrainingWeek>? TrainingWeeks { get; set; }
    }
}