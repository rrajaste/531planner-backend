using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IDailyNutritionIntakeRepository : IBaseRepository<Guid, DailyNutritionIntake>,
        IBaseRepository<DailyNutritionIntake>
    {
        
    }
    public interface IDailyNutritionIntakeRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity> 
        where TEntity : class, IDALBaseDTO<TKey>, new() 
        where TKey : IEquatable<TKey>
    {
        Task<TEntity> FindWithAppUserIdAsync(TKey id, Guid appUserId);
        Task<IEnumerable<TEntity>> AllWithAppUserIdAsync (TKey id);
    }
}