using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUserRole : IdentityRole
    {
        public override string Id { get; set; } = default!;
    }
}