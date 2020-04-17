using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Domain;
using TrainingCycle = DAL.App.DTO.TrainingCycle;

namespace Contracts.DAL.App.Repositories
{
    public interface ITrainingCycleRepository : ITrainingCycleRepository<Guid, TrainingCycle>
    {
    }

    public interface ITrainingCycleRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity> 
        where TEntity : class, IDALBaseDTO<TKey>, new() 
        where TKey : IEquatable<TKey>
    {
    }
}