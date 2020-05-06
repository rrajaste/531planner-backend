using BLL.Base.Mappers;
using Contracts.DAL.App;
using BLL.App.DTO;
using Contracts.BLL.App.Mappers;

namespace BLL.Mappers
{
    public class DailyNutritionIntakeMapper : BLLBaseMapper, IBLLMapper<DAL.App.DTO.DailyNutritionIntake, DailyNutritionIntake>
    {
        public DailyNutritionIntakeMapper(IAppBLLMapperContext context) : base(context)
        {
        }
        
        public DailyNutritionIntake MapDALToBLL(DAL.App.DTO.DailyNutritionIntake dalObject) => 
            new DailyNutritionIntake()
            {
                Id = dalObject.Id,
                AppUserId = dalObject.AppUserId,
                Calories = dalObject.Calories,
                Carbohydrates = dalObject.Carbohydrates,
                LoggedAt = dalObject.LoggedAt,
                Fats = dalObject.Fats,
                Protein = dalObject.Protein,
                UnitTypeId = dalObject.UnitTypeId,
                UnitType = dalObject.UnitType == null 
                    ? null 
                    : BLLMapperContext.UnitTypeMapper.MapDALToBLL(dalObject.UnitType)
            };

        public DAL.App.DTO.DailyNutritionIntake MapBLLToDAL(DailyNutritionIntake bllObject) =>
            new DAL.App.DTO.DailyNutritionIntake()
            {
                Id = bllObject.Id,
                AppUserId = bllObject.AppUserId,
                Calories = bllObject.Calories,
                Carbohydrates = bllObject.Carbohydrates,
                Fats = bllObject.Fats,
                Protein = bllObject.Protein,
                UnitTypeId = bllObject.UnitTypeId,
            };
    }
}