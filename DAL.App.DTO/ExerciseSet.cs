using System;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class ExerciseSet : ExerciseSet<Guid>, IDALBaseDTO
    {
    }

    public class ExerciseSet<TKey> : IDALBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public int SetNumber { get; set; }
        public bool Completed { get; set; }
        public int? NrOfReps { get; set; }
        public float? Weight { get; set; }
        public float? Duration { get; set; }
        public int? Distance { get; set; }
        public TKey UnitTypeId { get; set; } = default!;
        public TKey ExerciseInTrainingDayId { get; set; } = default!;
        public TKey WorkoutRoutineId { get; set; } = default!;
        public TKey SetTypeId { get; set; } = default!;
        public SetType? SetType { get; set; }
        public TrainingDay? TrainingDay { get; set; }
        public WorkoutRoutine? WorkoutRoutine { get; set; }
        public UnitType? UnitType { get; set; }
        public TKey Id { get; set; } = default!;
    }
}