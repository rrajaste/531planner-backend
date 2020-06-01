using System;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class SetType : SetType<Guid>, IDALBaseDTO
    {
    }

    public class SetType<TKey> : IDALBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string TypeCode { get; set; } = default!;
        public TKey Id { get; set; } = default!;
    }
}