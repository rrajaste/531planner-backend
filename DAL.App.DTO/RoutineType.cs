using System;
using Contracts.DAL.App;

namespace DAL.App.DTO
{
    public class RoutineType : RoutineType<Guid>, IDALBaseDTO
    {
    }
    public class RoutineType<TKey> : IDALBaseDTO<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}