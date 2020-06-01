using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IDailyNutritionIntakeRepository : IDailyNutritionIntakeRepository<Guid, DailyNutritionIntake>,
        IBaseRepository<DailyNutritionIntake>
    {
    }

    public interface IDailyNutritionIntakeRepository<in TKey, TEntity> : IBaseRepository<TKey, TEntity>
        where TEntity : class, IDALBaseDTO<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> AllWithAppUserIdAsync(TKey id);
        Task<TEntity> FindWithAppUserIdAsync(TKey id, TKey appUserId);
    }
}