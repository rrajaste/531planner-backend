using System;
using Contracts.DAL.Base;

namespace Contracts.Domain
{
    public interface IDomainEntityIdMetadata : IDomainEntityIdMetadata<Guid>
    {
    }

    public interface IDomainEntityIdMetadata<TKey> : IDomainEntityId<TKey>, IDomainEntityMetadata
        where TKey : IEquatable<TKey>
    {
    }
}