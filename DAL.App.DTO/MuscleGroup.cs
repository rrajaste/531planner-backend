using System;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain;

namespace DAL.App.DTO
{
    public class MuscleGroup : MuscleGroup<Guid>, IDALBaseDTO
    {
    }
    
    public class MuscleGroup<TKey> : IDALBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}