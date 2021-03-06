using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.raraja.Contracts.Domain;
using ee.itcollege.raraja.Domain;

namespace Domain.App
{
    public class ExerciseSet : ExerciseSet<Guid>, IDomainEntityIdMetadata
    {
    }

    public class ExerciseSet<TKey> : DomainEntityIdMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        [Display(Name = nameof(SetNumber), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public int SetNumber { get; set; } = default!;

        [Display(Name = nameof(Completed), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public bool Completed { get; set; } = default!;

        [Display(Name = nameof(NrOfReps), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public int? NrOfReps { get; set; }

        [Display(Name = nameof(Weight), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public float? Weight { get; set; }

        [Display(Name = nameof(Duration), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public float? Duration { get; set; }

        [Display(Name = nameof(Distance), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public int? Distance { get; set; }

        public TKey? UnitTypeId { get; set; } = default!;
        public TKey ExerciseInTrainingDayId { get; set; } = default!;
        public ExerciseInTrainingDay ExerciseInTrainingDay { get; set; } = default!;
        public TKey WorkoutRoutineId { get; set; } = default!;

        [Display(Name = nameof(WorkoutRoutine), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public WorkoutRoutine? WorkoutRoutine { get; set; }

        [Display(Name = nameof(UnitType), ResourceType = typeof(Resources.Domain.ExerciseSet))]
        public UnitType? UnitType { get; set; }

        public SetType? SetType { get; set; }
        public TKey SetTypeId { get; set; }
    }
}