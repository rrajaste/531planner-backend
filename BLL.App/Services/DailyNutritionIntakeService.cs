using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.Services
{
    public class DailyNutritionIntakeService :
        BaseEntityService<IDailyNutritionIntakeRepository, IAppUnitOfWork, DAL.App.DTO.DailyNutritionIntake,
            BLL.App.DTO.DailyNutritionIntake>, IDailyNutritionIntakeService
    {
        public DailyNutritionIntakeService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.DailyNutritionIntake,
                BLL.App.DTO.DailyNutritionIntake>(), unitOfWork.DailyNutritionIntakes)
        {
        }

        public async Task<IEnumerable<DailyNutritionIntake>> AllWithAppUserIdAsync(Guid id) => (
            await UnitOfWork.DailyNutritionIntakes.AllWithAppUserIdAsync(id)
        ).Select(Mapper.Map<DAL.App.DTO.DailyNutritionIntake, DailyNutritionIntake>);

        public async Task<DailyNutritionIntake> FindWithAppUserIdAsync(Guid id, Guid appUserId) =>
            Mapper.Map<DAL.App.DTO.DailyNutritionIntake, DailyNutritionIntake>(
                await UnitOfWork.DailyNutritionIntakes.FindWithAppUserIdAsync(id, appUserId));
    }
}