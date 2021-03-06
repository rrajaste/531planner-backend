using System;
using System.Collections.Generic;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class RoutineType : RoutineType<Guid>, IBLLBaseDTO
    {
    }

    public class RoutineType<TKey> : IBLLBaseDTO<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public RoutineType? ParentType { get; set; }
        public TKey? ParentTypeId { get; set; }
        public IEnumerable<RoutineType>? SubTypes { get; set; }
        public TKey Id { get; set; } = default!;
    }
}