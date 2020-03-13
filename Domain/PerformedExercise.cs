using System;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class PerformedExercise : DomainEntity
    {
        public int NrOfReps { get; set; }   
        public int NrOfSets { get; set; }   
        public decimal Weight { get; set; }   
        public int Distance { get; set; }   
        public int Duration { get; set; }

        public string AppUserId { get; set; }
        public string ExerciseId { get; set; }
        public string UnitsTypeId { get; set; }
        public string TrainingDayId { get; set; }
        public string WorkoutRoutineId { get; set; }
        public AppUser? User { get; set; }
        public Exercise? Exercise { get; set; }
        public UnitsType? UnitsType{ get; set; }
        public TrainingDay? TrainingDay{ get; set; }
        public WorkoutRoutine? WorkoutRoutine{ get; set; }
    }
}