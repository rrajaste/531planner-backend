using System;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class BaseCardioSet : BaseCardioSet<Guid>, IBLLBaseDTO
    {
    }

    public class BaseCardioSet<TKey> : IBLLBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public int SetNumber { get; set; }
        public float? Duration { get; set; }
        public TKey TrainingDayId { get; set; } = default!;
        public TKey ExerciseId { get; set; } = default!;
        public TKey WorkoutRoutineId { get; set; } = default!;
        public TKey SetTypeId { get; set; } = default!;
        public Exercise? Exercise { get; set; }
        public TrainingDay? TrainingDay { get; set; }
        public WorkoutRoutine? WorkoutRoutine { get; set; }
        public SetType? SetType { get; set; }
        public TKey Id { get; set; } = default!;
    }
}