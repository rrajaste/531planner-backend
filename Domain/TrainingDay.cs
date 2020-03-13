using System;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class TrainingDay : DomainEntity
    {
        public DateTime Date { get; set; }
        public string TrainingWeekId { get; set; }
        public string TrainingDayTypeId { get; set; }
        public TrainingWeek? TrainingWeek { get; set; }
        public TrainingDayType? TrainingDayType { get; set; }
    }
}