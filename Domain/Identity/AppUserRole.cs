using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUserRole : IdentityRole
    {
        public override string Id { get; set; } = default!;
    }
}