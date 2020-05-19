using System;
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
        
    }
}