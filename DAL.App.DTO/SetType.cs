using System;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class SetType : UnitType<Guid>, IDALBaseDTO
    {
    }
    public class SetType<TKey> : IDALBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}