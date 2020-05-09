using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;


namespace Contracts.DAL.App.Repositories
{
    public interface IWorkoutRoutineRepository : IWorkoutRoutineRepository<Guid, WorkoutRoutine>, IBaseRepository<WorkoutRoutine>
    {
    }

    public interface IWorkoutRoutineRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity> 
        where TEntity : class, IDALBaseDTO<TKey>, new() 
        where TKey : IEquatable<TKey>
    {
        Task<TEntity> ActiveRoutineForUserWithIdAsync(TKey userId);
        Task<IEnumerable<TEntity>> AllInactiveRoutinesForUserWithIdAsync(TKey userId);
        Task<IEnumerable<TEntity>> AllActiveBaseRoutinesAsync();
        Task<IEnumerable<TEntity>> AllInactiveBaseRoutinesAsync();
        Task<IEnumerable<TEntity>> AllUnPublishedBaseRoutinesAsync();
        Task<TEntity> FindBaseRoutineAsync(TKey id);
        Task<bool> BaseRoutineWithIdExistsAsync(TKey id);
        Task<WorkoutRoutine> AddWithBaseCycleAsync(TEntity dto);
    }
}