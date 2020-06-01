using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IDailyNutritionIntakeService : IBaseEntityService<DailyNutritionIntake>,
        IDailyNutritionIntakeRepository<Guid, DailyNutritionIntake>
    {
        Task<NutritionStatistics> GetNutritionStatisticsAsync(Guid userId, List<DailyNutritionIntake> userMeasurements);
    }
}