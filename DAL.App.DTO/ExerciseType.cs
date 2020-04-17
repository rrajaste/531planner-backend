
using System;
using Contracts.DAL.App;

namespace DAL.App.DTO
{
    public class ExerciseType : ExerciseType<Guid>, IDALBaseDTO
    {
    }
    
    public class ExerciseType<TKey> : IDALBaseDTO<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string TypeCode { get; set; } = default!;
    }
}