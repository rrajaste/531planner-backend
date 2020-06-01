using System;
using System.Collections.Generic;
using ee.itcollege.raraja.Domain;

namespace Domain.App
{
    public class ExerciseInTrainingDay : ExerciseInTrainingDay<Guid>
    {
    }

    public class ExerciseInTrainingDay<TKey> : DomainEntityIdMetadata<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey ExerciseId { get; set; } = default!;
        public Exercise? Exercise { get; set; }
        public TKey TrainingDayId { get; set; } = default!;
        public TrainingDay? TrainingDay { get; set; }
        public TKey ExerciseTypeId { get; set; } = default!;
        public ExerciseType? ExerciseType { get; set; }
        public ICollection<ExerciseSet>? ExerciseSets { get; set; }
    }
}