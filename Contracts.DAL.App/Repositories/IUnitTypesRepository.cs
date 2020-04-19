using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Domain;
using PublicApi.DTO.V1;
using UnitType = DAL.App.DTO.UnitType;

namespace Contracts.DAL.App.Repositories
{
    public interface IUnitTypesRepository : IUnitTypesRepository<Guid, UnitType>, IBaseRepository<UnitType>
    {
    }
    
    public interface IUnitTypesRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity> 
        where TEntity : class, IDALBaseDTO<TKey>, new() 
        where TKey : IEquatable<TKey>
    {
    }
}