using System;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IRoutineTypeRepository : IRoutineTypeRepository<Guid, RoutineType>, IBaseRepository<RoutineType>
    {
    }

    public interface IRoutineTypeRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity>
        where TEntity : class, IDALBaseDTO<TKey>, new()
        where TKey : IEquatable<TKey>
    {
    }
}