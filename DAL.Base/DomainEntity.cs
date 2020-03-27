using System;
using Contracts.DAL.Base;

namespace DAL.Base
{
    public abstract class DomainEntity :  DomainEntity<Guid>
    {
    }

    public abstract class DomainEntity<TKey> :  IDomainEntity<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public virtual TKey Id { get; set; }
        public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual DateTime ClosedAt { get; set; } = DateTime.MaxValue;
        public string? Comment { get; set; }
    }
}