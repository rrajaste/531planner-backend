using System;
using System.Collections.Generic;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class Exercise : Exercise<Guid>, IBLLBaseDTO
    {
    }

    public class Exercise<TKey> : IBLLBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public IEnumerable<MuscleGroup>? TargetMuscleGroups { get; set; }
        public TKey Id { get; set; } = default!;
    }
}