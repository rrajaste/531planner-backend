using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Domain;
using TrainingCycle = DAL.App.DTO.TrainingCycle;

namespace Contracts.DAL.App.Repositories
{
    public interface ITrainingCycleRepository : ITrainingCycleRepository<Guid, TrainingCycle>, IBaseRepository<TrainingCycle>
    {
    }

    public interface ITrainingCycleRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity> 
        where TEntity : class, IDALBaseDTO<TKey>, new() 
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> AllWithRoutineIdForUserWithIdAsync(TKey id, Guid? userId);
        Task<TEntity> FindWithRoutineIdForUserWithIdAsync(TKey id, TKey userId);
        Task<TEntity> FindWithBaseRoutineIdAsync(TKey id);
        Task<bool> IsPartOfBaseRoutineAsync(TKey cycleId);
        Task<TEntity> GetFullActiveCycleForUserWithIdAsync(TKey userId);
    }
}