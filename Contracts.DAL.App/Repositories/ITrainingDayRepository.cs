using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ITrainingDayRepository : ITrainingDayRepository<Guid, TrainingDay>, IBaseRepository<TrainingDay>
    {
    }

    public interface ITrainingDayRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity>
        where TEntity : class, IDALBaseDTO<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> AllWithTrainingWeekIdAsync(TKey trainingWeekId);
        Task<bool> IsPartOfBaseRoutineAsync(TKey trainingDayId);
        Task<TEntity> FindWithExerciseSetIdAsync(TKey id);
        Task<TEntity> FindWithExerciseInTrainingDayIdAsync(TKey id);
    }
}