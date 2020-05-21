using System;
using System.Collections.Generic;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class BaseTrainingDay : BaseTrainingDay<Guid>, IBLLBaseDTO
    {
    }

    public class BaseTrainingDay<TKey> : TrainingDay<TKey>
        where TKey : IEquatable<TKey>
    {
        public DayOfWeek DayOfWeek { get; set; }
    }
}