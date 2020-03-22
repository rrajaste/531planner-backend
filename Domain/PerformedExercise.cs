using System;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class PerformedExercise : DomainEntity
    {
        public int NrOfReps { get; set; }   
        public int NrOfSets { get; set; }   
        public decimal Weight { get; set; }   
        public int Distance { get; set; }   
        public int Duration { get; set; }

        public Guid AppUserId { get; set; }
        public Guid ExerciseId { get; set; }
        public Guid UnitsTypeId { get; set; }
        public Guid TrainingDayId { get; set; }
        public Guid WorkoutRoutineId { get; set; }
        public AppUser? User { get; set; }
        public Exercise? Exercise { get; set; }
        public UnitsType? UnitsType{ get; set; }
        public TrainingDay? TrainingDay{ get; set; }
        public WorkoutRoutine? WorkoutRoutine{ get; set; }
    }
}