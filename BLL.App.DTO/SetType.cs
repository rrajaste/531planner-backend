using System;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class SetType : SetType<Guid>, IBLLBaseDTO
    {
    }
    
    public class SetType<TKey> : IBLLBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string TypeCode { get; set; } = default!;
    }
}