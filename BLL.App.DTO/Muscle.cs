using System;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class Muscle : Muscle<Guid>, IBLLBaseDTO
    {
    }

    public class Muscle<TKey> : IBLLBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public TKey MuscleGroupId { get; set; } = default!;
        public MuscleGroup? MuscleGroup { get; set; } = default!;
        public TKey Id { get; set; } = default!;
    }
}