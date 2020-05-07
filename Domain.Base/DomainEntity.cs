using System;
using Contracts.DAL.Base;

namespace DAL.Base
{
    public abstract class DomainEntityBaseMetadata :  DomainEntityBaseMetadata<Guid>
    {
    }

    public abstract class DomainEntityBaseMetadata<TKey> :  IDomainEntityBaseMetadata<TKey> 
        where TKey : IEquatable<TKey>
    {
        public virtual TKey Id { get; set; } = default!;
        public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual DateTime ClosedAt { get; set; } = DateTime.MaxValue;
        public string? Comment { get; set; }
    }
}