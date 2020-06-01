using System;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class PersonalRecord : PersonalRecord<Guid>, IBLLBaseDTO
    {
    }

    public class PersonalRecord<TKey> : IBLLBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey WorkoutRoutineId { get; set; } = default!;
        public TKey AppUserId { get; set; } = default!;
        public TKey ExerciseSetId { get; set; } = default!;
        public WorkoutRoutine? WorkoutRoutine { get; set; }
        public ExerciseSet? ExerciseSet { get; set; }
        public TKey Id { get; set; } = default!;
    }
}