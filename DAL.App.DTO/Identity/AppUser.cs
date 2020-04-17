using System;
using Contracts.DAL.Base;

namespace DAL.App.DTO.Identity
{
    public class AppUser : AppUser<Guid>, IDomainBaseEntity<Guid>
    {
    }
    
    public class AppUser<TKey> : IDomainBaseEntity<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Email { get; set; }  = default!;
    }
}