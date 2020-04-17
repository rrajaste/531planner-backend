using System;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Domain;
using TrainingWeek = DAL.App.DTO.TrainingWeek;

namespace Contracts.DAL.App.Repositories
{
    public interface ITrainingWeekRepository : ITrainingWeekRepository<Guid, TrainingWeek> 
    {
    }
    
    public interface ITrainingWeekRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity> 
        where TEntity : class, IDALBaseDTO<TKey>, new() 
        where TKey : IEquatable<TKey>
    {
    }
}