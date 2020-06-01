using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.Base.EF;
using Domain.App;

namespace DAL.App.EF.Mappers
{
    public class DailyNutritionIntakeMapper : EFBaseMapper, IDALMapper<DailyNutritionIntake, DTO.DailyNutritionIntake>
    {
        public DailyNutritionIntakeMapper(IAppDALMapperContext context) : base(context)
        {
        }

        public DTO.DailyNutritionIntake MapDomainToDAL(DailyNutritionIntake domainObject)
        {
            return new DTO.DailyNutritionIntake
            {
                Id = domainObject.Id,
                AppUserId = domainObject.AppUserId,
                Calories = domainObject.Calories,
                Carbohydrates = domainObject.Carbohydrates,
                LoggedAt = domainObject.LoggedAt,
                Fats = domainObject.Fats,
                Protein = domainObject.Protein
            };
        }

        public DailyNutritionIntake MapDALToDomain(DTO.DailyNutritionIntake dalObject)
        {
            return new DailyNutritionIntake
            {
                Id = dalObject.Id,
                AppUserId = dalObject.AppUserId,
                Calories = dalObject.Calories,
                Carbohydrates = dalObject.Carbohydrates,
                Fats = dalObject.Fats,
                Protein = dalObject.Protein
            };
        }
    }
}