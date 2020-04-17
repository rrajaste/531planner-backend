using System;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain.Identity;

namespace DAL.App.DTO
{
    public class PersonalRecord : PersonalRecord<Guid>, IDALBaseDTO
    {
    }

    public class PersonalRecord<TKey> : IDALBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public TKey WorkoutRoutineId { get; set; } = default!;
        public TKey AppUserId { get; set; } = default!;
        public AppUser<TKey>? AppUser { get; set; }
        public TKey ExerciseSetId { get; set; } = default!;
        public WorkoutRoutine? WorkoutRoutine { get; set; }
        public ExerciseSet? ExerciseSet { get; set; }
    }
}