using System;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class BaseLiftSet : BaseLiftSet<Guid>, IBLLBaseDTO
    {
        
    }
    public class BaseLiftSet<TKey> : IBLLBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public int SetNumber { get; set; }
        public int NrOfReps { get; set; }
        public float WeightPercentageOfOneRepMax { get; set; }
        public TKey TrainingDayId { get; set; } = default!;
        public TKey ExerciseId { get; set; } = default!;
        public TKey WorkoutRoutineId { get; set; } = default!;
        public TKey SetTypeId { set; get; } = default!;
        public Exercise? Exercise { get; set; }
        public TrainingDay? TrainingDay { get; set; }
        public WorkoutRoutine? WorkoutRoutine { get; set; }
        public SetType? SetType { get; set; }
    }
}