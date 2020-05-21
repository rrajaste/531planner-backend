using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IExerciseInTrainingDayRepository : IExerciseInTrainingDayRepository<Guid, ExerciseInTrainingDay>, 
        IBaseRepository<ExerciseInTrainingDay>
    {
        
    }
    
    public interface IExerciseInTrainingDayRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity> 
        where TEntity : class, IDALBaseDTO<TKey>, new() 
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> AllWithBaseTrainingDayIdAsync(TKey trainingDayId);
        Task<bool> IsPartOfBaseRoutineAsync(TKey id);
        
    }
}