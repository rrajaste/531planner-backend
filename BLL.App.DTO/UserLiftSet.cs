using System;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class UserLiftSet : UserLiftSet<Guid>, IBLLBaseDTO
    {
    }

    public class UserLiftSet<TKey> : IBLLBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public int SetNumber { get; set; }
        public int NrOfReps { get; set; }
        public float Weight { get; set; }
        public TKey ExerciseInTrainingDayId { get; set; } = default!;
        public TKey WorkoutRoutineId { get; set; } = default!;
        public TKey UnitTypeId { get; set; } = default!;
        public TKey SetTypeId { set; get; } = default!;
        public Exercise? Exercise { get; set; }
        public TrainingDay? TrainingDay { get; set; }
        public WorkoutRoutine? WorkoutRoutine { get; set; }
        public UnitType? UnitType { get; set; }
        public SetType? SetType { get; set; }
        public TKey Id { get; set; } = default!;
    }
}