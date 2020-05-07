using System;
using Contracts.DAL.Base;

namespace Domain.Base
{
    public abstract class DomainEntityMetadata : IDomainEntityMetadata
    {
        public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual DateTime ClosedAt { get; set; } = DateTime.MaxValue;
        public virtual string? Comment { get; set; }
    }
}