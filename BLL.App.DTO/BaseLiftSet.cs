using System;
using System.ComponentModel.DataAnnotations;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class BaseLiftSet : BaseLiftSet<Guid>, IBLLBaseDTO
    {
    }

    public class BaseLiftSet<TKey> : IBLLBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public int SetNumber { get; set; }

        [Display(Name = nameof(NrOfReps), ResourceType = typeof(Resources.BLL.BaseLiftSet))]
        public int NrOfReps { get; set; }

        [Display(Name = nameof(WeightPercentageOfOneRepMax), ResourceType = typeof(Resources.BLL.BaseLiftSet))]
        public float WeightPercentageOfOneRepMax { get; set; }

        public TKey ExerciseInTrainingDayId { get; set; } = default!;
        public TKey WorkoutRoutineId { get; set; } = default!;
        public TKey SetTypeId { set; get; } = default!;
        public WorkoutRoutine? WorkoutRoutine { get; set; }

        [Display(Name = nameof(SetType), ResourceType = typeof(Resources.BLL.BaseLiftSet))]
        public SetType? SetType { get; set; }

        public TKey Id { get; set; } = default!;
    }
}