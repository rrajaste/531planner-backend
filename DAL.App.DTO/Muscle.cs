using System;

using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class Muscle : Muscle<Guid>, IDALBaseDTO
    {
    }
    
    public class Muscle<TKey> : IDALBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public TKey MuscleGroupId { get; set; } = default!;
        public MuscleGroup MuscleGroup { get; set; } = default!;
    }
}