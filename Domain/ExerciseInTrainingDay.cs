using System;
using DAL.Base;

namespace Domain
{
    public class ExerciseInTrainingDay : DomainEntity
    {
        public Guid TrainingDayId { get; set; }
        public Guid ExerciseId { get; set; }
        public TrainingDay? TrainingDay { get; set; }
        public Exercise? Exercise { get; set; }
    }
}