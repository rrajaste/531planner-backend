using System;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class TrainingDayType : TrainingDayType<Guid>, IDALBaseDTO
    {
    }

    public class TrainingDayType<TKey> : IDALBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public TKey Id { get; set; } = default!;
    }
}