using System;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IExerciseRepository : IExerciseRepository<Guid, Exercise>, IBaseRepository<Exercise>
    {
    }

    public interface IExerciseRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity>
        where TEntity : class, IDALBaseDTO<TKey>, new()
        where TKey : IEquatable<TKey>
    {
    }
}