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
        TKey AppUserId { get; set; }
        IdentityUser<TKey>? AppUser { get; set; }
    }
}