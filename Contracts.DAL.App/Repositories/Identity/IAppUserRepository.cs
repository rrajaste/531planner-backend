using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain.Identity;

namespace Contracts.DAL.App.Repositories.Identity
{
    public interface IAppUserRepository : IBaseRepository<AppUser>
    {
        Task<bool> UserWithEmailExists(string email);
    }
}