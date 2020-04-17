using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;


namespace Contracts.DAL.App.Repositories
{
    public interface IWorkoutRoutineRepository : IWorkoutRoutineRepository<Guid, WorkoutRoutine>
    {
    }

    public interface IWorkoutRoutineRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity> 
        where TEntity : class, IDALBaseDTO<TKey>, new() 
        where TKey : IEquatable<TKey>
    {
        Task<TEntity> ActiveRoutineForUserIdAsync(TKey id);
        Task<IEnumerable<TEntity>> AllNonActiveRoutinesForUserIdAsync(TKey id);
        Task<IEnumerable<TEntity>> AllBaseRoutinesAsync();
    }
}