using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUserRole : AppUserRole<Guid>
    {
    }

    public class AppUserRole<TKey> : IdentityRole<TKey> where TKey : IEquatable<TKey>
    {
    }

}