using System;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class TrainingDayType : TrainingDayType<Guid>, IBLLBaseDTO
    {
    }

    public class TrainingDayType<TKey> : IBLLBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public TKey Id { get; set; } = default!;
    }
}