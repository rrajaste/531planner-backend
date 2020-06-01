using BLL.Base.Mappers;
using Contracts.BLL.App;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;

namespace BLL.Mappers
{
    public class DailyNutritionIntakeMapper : BLLBaseMapper,
        IBLLMapper<DailyNutritionIntake, App.DTO.DailyNutritionIntake>
    {
        public DailyNutritionIntakeMapper(IAppBLLMapperContext context) : base(context)
        {
        }

        public App.DTO.DailyNutritionIntake MapDALToBLL(DailyNutritionIntake dalObject)
        {
            return new App.DTO.DailyNutritionIntake
            {
                Id = dalObject.Id,
                AppUserId = dalObject.AppUserId,
                Calories = dalObject.Calories,
                Carbohydrates = dalObject.Carbohydrates,
                LoggedAt = dalObject.LoggedAt,
                Fats = dalObject.Fats,
                Protein = dalObject.Protein
            };
        }

        public DailyNutritionIntake MapBLLToDAL(App.DTO.DailyNutritionIntake bllObject)
        {
            return new DailyNutritionIntake
            {
                Id = bllObject.Id,
                AppUserId = bllObject.AppUserId,
                Calories = bllObject.Calories,
                Carbohydrates = bllObject.Carbohydrates,
                Fats = bllObject.Fats,
                Protein = bllObject.Protein
            };
        }
    }
}