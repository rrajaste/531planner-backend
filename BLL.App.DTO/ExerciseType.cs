using System;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class ExerciseType : ExerciseType<Guid>, IBLLBaseDTO
    {
    }

    public class ExerciseType<TKey> : IBLLBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string TypeCode { get; set; } = default!;
        public TKey Id { get; set; } = default!;
    }
}