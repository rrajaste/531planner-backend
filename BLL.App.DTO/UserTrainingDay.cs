using System;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class UserTrainingDay : UserTrainingDay<Guid>, IBLLBaseDTO
    {
    }

    public class UserTrainingDay<TKey> : TrainingDay<TKey>
        where TKey : IEquatable<TKey>
    {
        public DateTime Date { get; set; }
    }
}