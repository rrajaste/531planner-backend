using System;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class RoutineType : RoutineType<Guid>, IBLLBaseDTO
    {
    }
    public class RoutineType<TKey> : IBLLBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}