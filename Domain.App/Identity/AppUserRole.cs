using System;
using Contracts.DAL.Base;
using Contracts.Domain;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUserRole : AppUserRole<Guid>
    {
    }

    public class AppUserRole<TKey> : IdentityRole<TKey>, IDomainEntityIdMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string DisplayName { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ClosedAt { get; set; } = DateTime.MaxValue;
        public string? Comment { get; set; }
    }

}