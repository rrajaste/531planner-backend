using System;
using Contracts.BLL.Base;
using Contracts.DAL.Base;

namespace BLL.App.DTO
{
    public class ExerciseSet : ExerciseSet<Guid>, IBLLBaseDTO
    {
        
    }

    public class ExerciseSet<TKey> : IBLLBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public int SetNumber { get; set; }
        public bool Completed { get; set; }
        public int? NrOfReps { get; set; }
        public float? Weight { get; set; }
        public float? Duration { get; set; }
        public int? Distance { get; set; }
        public TKey UnitTypeId { get; set; } = default!;
        public TKey TrainingDayId { get; set; } = default!;
        public TKey ExerciseId { get; set; } = default!;
        public TKey WorkoutRoutineId { get; set; } = default!;
        public Exercise? Exercise { get; set; }
        public TrainingDay? TrainingDay { get; set; }
        public WorkoutRoutine? WorkoutRoutine { get; set; }
        public UnitType? UnitType { get; set; }
    }
}