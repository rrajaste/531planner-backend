using System;
using System.Collections.Generic;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class RoutineType : RoutineType<Guid>, IDALBaseDTO
    {
    }

    public class RoutineType<TKey> : IDALBaseDTO<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public TKey? ParentTypeId { get; set; }
        public IEnumerable<RoutineType>? SubTypes { get; set; }
        public TKey Id { get; set; } = default!;
    }
}