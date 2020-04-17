using System;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using ExerciseType = DAL.App.DTO.ExerciseType;

namespace Contracts.DAL.App.Repositories
{
    public interface IExerciseTypeRepository : IExerciseTypeRepository<Guid, ExerciseType>
    {
    }
    
    public interface IExerciseTypeRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity> 
        where TEntity : class, IDALBaseDTO<TKey>, new() 
        where TKey : IEquatable<TKey>
    {
        
    }
}