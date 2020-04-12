using System;
using System.ComponentModel.DataAnnotations;
using DAL.Base;

namespace Domain
{
    public class ExerciseSet : DomainEntity
    {
        [Display(Name = nameof(SetNumber), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public int SetNumber { get; set; } = default!;
        [Display(Name = nameof(Completed), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public bool Completed { get; set; } = default!;
        [Display(Name = nameof(NrOfReps), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public int? NrOfReps { get; set; }
        [Display(Name = nameof(Weight), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public float? Weight { get; set; }
        [Display(Name = nameof(Duration), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public float? Duration { get; set; }
        [Display(Name = nameof(Distance), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public int? Distance { get; set; }
        public Guid UnitTypeId { get; set; }
        public Guid TrainingDayId { get; set; }
        public Guid ExerciseId { get; set; }
        public Guid WorkoutRoutineId { get; set; }
        
        [Display(Name = nameof(Exercise), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public Exercise? Exercise { get; set; }
        
        [Display(Name = nameof(TrainingDay), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public TrainingDay? TrainingDay { get; set; }
        
        [Display(Name = nameof(WorkoutRoutine), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public WorkoutRoutine? WorkoutRoutine { get; set; }
        [Display(Name = nameof(UnitType), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public UnitType? UnitType { get; set; }
    }
}