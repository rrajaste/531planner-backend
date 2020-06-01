using System;
using System.Collections.Generic;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class MuscleGroup : MuscleGroup<Guid>, IBLLBaseDTO
    {
    }

    public class MuscleGroup<TKey> : IBLLBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public IEnumerable<Muscle>? Muscles { get; set; }
        public TKey Id { get; set; } = default!;
    }
}