using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.App.Repositories
{
    public interface IProtectedInformationRepository<TEntity> : IBaseRepository<TEntity, Guid>
        where TEntity : class, IDomainEntity<Guid>, new()
    {
    }

    public interface IProtectedInformationRepository<TEntity, TKey>
        where TEntity : class, IDomainEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
        IEnumerable<TEntity> AllAuthorize(TKey userId);
        Task<IEnumerable<TEntity>> AllAsyncAuthorize(TKey userId);
        TEntity FindAuthorize(object id, TKey userId);
        Task<TEntity> FindAsyncAuthorize(object id);
        TEntity AddAuthorize(TEntity entity, TKey userId);
        TEntity UpdateAuthorize(TEntity entity, TKey userId);
        TEntity RemoveAuthorize(TEntity entity, TKey userId);
    }
}