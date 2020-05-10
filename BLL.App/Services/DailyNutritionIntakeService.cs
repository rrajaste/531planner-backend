using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class DailyNutritionIntakeService :
        BaseEntityService<IDailyNutritionIntakeRepository, IAppUnitOfWork, DAL.App.DTO.DailyNutritionIntake,
            BLL.App.DTO.DailyNutritionIntake, IBLLMapper<DAL.App.DTO.DailyNutritionIntake, BLL.App.DTO.DailyNutritionIntake>>,
        IDailyNutritionIntakeService
    {
        public DailyNutritionIntakeService(IAppUnitOfWork unitOfWork, IBLLMapper<DAL.App.DTO.DailyNutritionIntake, DailyNutritionIntake> mapper) 
            : base(unitOfWork, mapper, unitOfWork.DailyNutritionIntakes)
        {
        }

        public async Task<IEnumerable<DailyNutritionIntake>> AllWithAppUserIdAsync(Guid id) => (
            await UnitOfWork.DailyNutritionIntakes.AllWithAppUserIdAsync(id)
        ).Select(Mapper.MapDALToBLL);

        public async Task<DailyNutritionIntake> FindWithAppUserIdAsync(Guid id, Guid appUserId) =>
            Mapper.MapDALToBLL(
                await UnitOfWork.DailyNutritionIntakes.FindWithAppUserIdAsync(id, appUserId));
    }
}