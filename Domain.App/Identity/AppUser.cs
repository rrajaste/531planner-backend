using System;
using System.Collections.Generic;
using ee.itcollege.raraja.Contracts.Domain;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity
{
    public class AppUser : AppUser<Guid>
    {
    }

    public class AppUser<TKey> : IdentityUser<TKey>, IDomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public bool AccountLocked { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ClosedAt { get; set; } = DateTime.MaxValue;
        public string? Comment { get; set; }
    }
}