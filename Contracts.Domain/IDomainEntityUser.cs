using System;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Domain
{
    public interface IDomainEntityUser : IDomainEntityUser<Guid>
    {
    }

    public interface IDomainEntityUser<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey AppUserId { get; set; }
        public IdentityUser<TKey>? AppUser { get; set; }
    }
}