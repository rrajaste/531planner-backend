using System;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class ExerciseInTrainingDay : DomainEntity
    {
        public string TrainingDayId { get; set; }
        public string ExerciseId { get; set; }
        public TrainingDay? TrainingDay { get; set; }
        public Exercise? Exercise { get; set; }
    }
}