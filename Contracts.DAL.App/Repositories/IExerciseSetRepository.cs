using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;


namespace Contracts.DAL.App.Repositories
{
    public interface IExerciseSetRepository : IExerciseSetRepository<Guid, ExerciseSet>, IBaseRepository<ExerciseSet>
    {
    }
    
    public interface IExerciseSetRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity> 
        where TEntity : class, IDALBaseDTO<TKey>, new() 
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> AllWithExerciseInTrainingDayIdAsync(Guid exerciseInTrainingDayId);
        Task<bool> IsPartOfBaseRoutineAsync(Guid exerciseSetId);
        Task<TKey> GetRoutineIdForExerciseSetAsync(TKey exerciseInTrainingDayId);
    }
}