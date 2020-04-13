using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IDailyNutritionIntakeRepository : IBaseRepository<DailyNutritionIntake>
    {
        Task<DailyNutritionIntake> FindWithAppUserIdAsync(Guid? id, Guid appUserId);
        Task<IEnumerable<DailyNutritionIntake>> AllWithAppUserIdAsync (Guid id);
    }
}