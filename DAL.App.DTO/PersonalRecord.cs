using System;
using Contracts.DAL.App;
using Domain.Identity;

namespace DAL.App.DTO
{
    public class PersonalRecord : PersonalRecord<Guid>, IDALBaseDTO
    {
    }

    public class PersonalRecord<TKey> : IDALBaseDTO<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public TKey? WorkoutRoutineId { get; set; }
        public TKey AppUserId { get; set; }
        public AppUser<TKey>? AppUser { get; set; }
        public TKey ExerciseSetId { get; set; }
        public WorkoutRoutine? WorkoutRoutine { get; set; }
        public ExerciseSet? ExerciseSet { get; set; }
    }
}