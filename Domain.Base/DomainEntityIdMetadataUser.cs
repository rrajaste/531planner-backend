using System;
using ee.itcollege.raraja.Contracts.Domain;
using Microsoft.AspNetCore.Identity;

namespace Domain.Base
{
    public abstract class DomainEntityIdMetadataUser : DomainEntityIdMetadataUser<Guid>, IDomainEntityUser
    {
    }

    public abstract class DomainEntityIdMetadataUser<TKey> : DomainEntityIdMetadata<TKey>,
        IDomainEntityUser<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey AppUserId { get; set; } = default!;

        public IdentityUser<TKey>? AppUser { get; set; }
    }
}