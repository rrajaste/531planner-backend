using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories.Identity;
using DAL.Base.EF.Repositories;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories.Identity
{
    public class AppUserRoleRepository : EFBaseRepository<AppUserRole, AppDbContext>, IAppUserRoleRepository
    {
        public AppUserRoleRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}