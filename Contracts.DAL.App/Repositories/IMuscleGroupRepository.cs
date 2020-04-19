using System;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using MuscleGroup = DAL.App.DTO.MuscleGroup;

namespace Contracts.DAL.App.Repositories
{
    public interface IMuscleGroupRepository : IMuscleGroupRepository<Guid, MuscleGroup>, IBaseRepository<MuscleGroup>
    {
    }
    
    public interface IMuscleGroupRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity> 
        where TEntity : class, IDALBaseDTO<TKey>, new() where TKey : IEquatable<TKey>
    {
    }
}