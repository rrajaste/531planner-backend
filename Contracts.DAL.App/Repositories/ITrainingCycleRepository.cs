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
        Task<IEnumerable<TEntity>> AllWithRoutineIdForUserWithIdAsync(Guid id, Guid? userId);
        Task<IEnumerable<TEntity>> AllWithBaseRoutineIdAsync(Guid id);
        Task<TEntity> FindWithRoutineIdForUserWithIdAsync(Guid id, Guid? userId);
        Task<TEntity> FindWithBaseRoutineIdAsync(Guid id);
    }
}