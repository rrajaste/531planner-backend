using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IBodyMeasurementRepository : IBodyMeasurementRepository<Guid, BodyMeasurement>,
        IBaseRepository<BodyMeasurement>
    {
    }

    public interface IBodyMeasurementRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity>
        where TEntity : class, IDALBaseDTO<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> AllWithAppUserIdAsync(TKey id);
        Task<TEntity> FindWithAppUserIdAsync(TKey id, TKey appUserId);
        Task<TEntity> FirstForUserWithIdAsync(TKey userId);
        Task<TEntity> LatestForUserWithIdAsync(TKey userId);
    }
}