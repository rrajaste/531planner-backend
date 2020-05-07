using System;
using Microsoft.AspNetCore.Identity;

namespace Contracts.DAL.Base
{
    public interface IDomainEntityUser<TUser> : IDomainEntityUser<TUser, Guid>
        where TUser : IdentityUser<Guid>
    {
    }
    
    public interface IDomainEntityUser<TUser, TKey> 
        where TKey : IEquatable<TKey> 
        where TUser : IdentityUser<TKey>
    {
        public TKey AppUserId { get; set; }
    }
}