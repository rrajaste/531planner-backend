using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IWorkoutRoutineRepository : IWorkoutRoutineRepository<Guid, WorkoutRoutine>,
        IBaseRepository<WorkoutRoutine>
    {
    }

    public interface IWorkoutRoutineRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity>
        where TEntity : class, IDALBaseDTO<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        Task<TEntity> ActiveRoutineForUserWithIdAsync(TKey userId);
        Task<bool> ActiveRoutineWithIdExistsForUserAsync(Guid routineId, Guid userId);
        Task<IEnumerable<TEntity>> AllInactiveRoutinesForUserWithIdAsync(TKey userId);
        Task<IEnumerable<TEntity>> AllActiveBaseRoutinesAsync();
        Task<IEnumerable<TEntity>> AllInactiveBaseRoutinesAsync();
        Task<IEnumerable<TEntity>> AllUnPublishedBaseRoutinesAsync();
        Task<IEnumerable<TEntity>> AllPublishedBaseRoutinesAsync();
        Task<TEntity> FindBaseRoutineAsync(TKey id);
        Task<bool> BaseRoutineWithIdExistsAsync(TKey id);
        Task AddWithBaseCycleAsync(TEntity dto);
        Task<TEntity> ChangeRoutinePublishStatus(TKey routineId, bool isPublished);
        Task<TEntity> FindWithWeekIdAsync(TKey weekId);
        Task<TEntity> FindWithTrainingDayIdAsync(Guid trainingDayId);
        Task<TEntity> FindFullRoutineWithIdAsync(Guid routineId);
        Task<bool> UserWithIdHasActiveRoutineAsync(Guid userId);
        void UpdateBaseRoutine(TEntity routine);
    }
}