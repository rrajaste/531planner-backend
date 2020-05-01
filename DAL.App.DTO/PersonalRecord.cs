using System;
using Contracts.DAL.Base;

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
        public TKey ExerciseSetId { get; set; } = default!;
        public ExerciseSet? ExerciseSet { get; set; }
    }
}