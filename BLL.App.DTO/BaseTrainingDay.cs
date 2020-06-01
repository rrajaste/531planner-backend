using System;
using System.ComponentModel.DataAnnotations;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class BaseTrainingDay : BaseTrainingDay<Guid>, IBLLBaseDTO
    {
    }

    public class BaseTrainingDay<TKey> : TrainingDay<TKey>
        where TKey : IEquatable<TKey>
    {
        [Display(Name = nameof(DayOfWeek), ResourceType = typeof(Resources.BLL.TrainingDay))]
        public DayOfWeek DayOfWeek { get; set; }
    }
}