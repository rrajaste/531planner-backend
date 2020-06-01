using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IWorkoutRoutineInfoRepository : IWorkoutRoutineInfoRepository<Guid, WorkoutRoutineInfo>,
        IBaseRepository<WorkoutRoutineInfo>
    {
    }

    public interface IWorkoutRoutineInfoRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity>
        where TEntity : class, IDALBaseDTO<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> AllForWorkoutRoutineWithIdAsync(Guid routineId);
    }
}