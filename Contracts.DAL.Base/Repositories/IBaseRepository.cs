using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.DAL.Base.Repositories
{
    public interface IBaseRepository<TDALEntity> : IBaseRepository<Guid, TDALEntity>
        where TDALEntity : class, IDALBaseDTO<Guid>, new()
    {
    }

    public interface IBaseRepository<in TKey, TDALEntity>
        where TKey : IEquatable<TKey>
    {
        IEnumerable<TDALEntity> All();
        Task<IEnumerable<TDALEntity>> AllAsync();
        TDALEntity Find(TKey id);
        Task<TDALEntity> FindAsync(TKey id);
        TDALEntity Add(TDALEntity entity);
        TDALEntity Update(TDALEntity entity);
        TDALEntity Remove(TDALEntity entity);
        TDALEntity Remove(TKey id);
    }
}