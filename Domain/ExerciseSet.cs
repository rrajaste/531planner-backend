using System;
using DAL.Base;

namespace Domain
{
    public class ExerciseSet : DomainEntity
    {
        public int SetNumber { get; set; } = default!;
        public bool Completed { get; set; } = default!;
        public int? NrOfReps { get; set; }
        public float? Weight { get; set; }
        public float? Duration { get; set; }
        public int? Distance { get; set; }
        public Guid UnitTypeId { get; set; }
        public Guid TrainingDayId { get; set; }
        public Guid ExerciseId { get; set; }
        public Guid WorkoutRoutineId { get; set; }
        public Exercise? Exercise { get; set; }
        public TrainingDay? TrainingDay { get; set; }
        public WorkoutRoutine? WorkoutRoutine { get; set; }
        public UnitType? UnitType { get; set; }
    }
}