using System;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using Contracts.Domain;

namespace Domain.Base
{
    public abstract class DomainEntityIdMetadata : DomainEntityIdMetadata<Guid>, IDomainEntityId, IDomainEntityMetadata
    {
    }

    public abstract class DomainEntityIdMetadata<TKey> : DomainEntityId<TKey>, IDomainEntityIdMetadata<TKey>
        where TKey : IEquatable<TKey>
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ClosedAt { get; set; } = DateTime.MaxValue;
        [MaxLength(1024)]
        public string? Comment { get; set; }
    }
}