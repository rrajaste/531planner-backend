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
        
        [Display(Name = nameof(CycleNumber), ResourceType = typeof(Resources.Domain.TrainingCycle))]
        public int CycleNumber { get; set; }
        
        [Display(Name = nameof(StartingDate), ResourceType = typeof(Resources.Domain.TrainingCycle))]

        public DateTime StartingDate { get; set; }
        
        [Display(Name = nameof(EndingDate), ResourceType = typeof(Resources.Domain.TrainingCycle))]
        public DateTime? EndingDate { get; set; }
        
        [Display(Name = nameof(WorkoutRoutine), ResourceType = typeof(Resources.Domain.TrainingCycle))]

        public WorkoutRoutine? WorkoutRoutine { get; set; }
        
        public ICollection<TrainingWeek>? TrainingWeeks { get; set; }
    }
}