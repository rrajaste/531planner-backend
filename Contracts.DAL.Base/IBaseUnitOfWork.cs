using System;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.Base
{
    public interface IBaseUnitOfWork
    {
        Task<int> SaveChangesAsync();
        TRepository GetRepository<TRepository>(Func<TRepository> repoCreationMethod);
    }
}