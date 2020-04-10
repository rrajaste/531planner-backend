using System.Threading.Tasks;
using Contracts.DAL.App.Repositories.Identity;
using DAL.Base.EF.Repositories;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories.Identity
{
    public class AppUserRepository : EFBaseRepository<AppUser, AppDbContext>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> UserWithEmailExists(string email)
        {
            return await RepoDbSet.AnyAsync(e => e.Email == email);
        }
    }
}