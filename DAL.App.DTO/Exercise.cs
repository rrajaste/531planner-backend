using System;
using System.Collections.Generic;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class Exercise : Exercise<Guid>, IDALBaseDTO
    {
    }
    
    public class Exercise<TKey> : IDALBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public IEnumerable<MuscleGroup>? TargetMuscleGroups { get; set; }
    }
}