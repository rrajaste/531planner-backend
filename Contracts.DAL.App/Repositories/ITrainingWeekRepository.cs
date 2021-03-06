using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ITrainingWeekRepository : ITrainingWeekRepository<Guid, TrainingWeek>,
        IBaseRepository<TrainingWeek>
    {
    }

    public interface ITrainingWeekRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity>
        where TEntity : class, IDALBaseDTO<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> AllWithBaseRoutineIdAsync(Guid baseRoutineId);
        Task<bool> IsPartOfBaseRoutineAsync(Guid id);
        Task<TEntity> FindAsync(Guid id, bool includeTrainingDays = false);
    }
}