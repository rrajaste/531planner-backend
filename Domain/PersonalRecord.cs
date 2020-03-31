using System;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class PersonalRecord : DomainEntity
    {
        public Guid? WorkoutRoutineId { get; set; }
        public Guid AppUserId { get; set; }
        public Guid ExerciseSetId { get; set; }
        public WorkoutRoutine? WorkoutRoutine { get; set; }
        public AppUser? User { get; set; }
        public ExerciseSet? ExerciseSet { get; set; }
    }
}