using System;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Contracts.DAL.App.Repositories
{
    public interface ITrainingDayTypeRepository : ITrainingDayTypeRepository<Guid, TrainingDayType>, IBaseRepository<TrainingDayType>
    {
    }

    public interface ITrainingDayTypeRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity> 
        where TEntity : class, IDALBaseDTO<TKey>, new() 
        where TKey : IEquatable<TKey>
    {
    }
}