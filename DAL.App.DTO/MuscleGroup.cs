using System;
using Contracts.DAL.App;
using Domain;

namespace DAL.App.DTO
{
    public class MuscleGroup : MuscleGroup<Guid>, IDALBaseDTO
    {
    }
    
    public class MuscleGroup<TKey> : IDALBaseDTO<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}