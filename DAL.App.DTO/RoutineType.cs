using System;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class RoutineType : RoutineType<Guid>, IDALBaseDTO
    {
    }
    public class RoutineType<TKey> : IDALBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}