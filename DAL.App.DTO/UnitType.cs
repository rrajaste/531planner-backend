
using System;
using Contracts.DAL.App;

namespace DAL.App.DTO
{
    public class UnitType : UnitType<Guid>, IDALBaseDTO
    {
    }
    public class UnitType<TKey> : IDALBaseDTO<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}