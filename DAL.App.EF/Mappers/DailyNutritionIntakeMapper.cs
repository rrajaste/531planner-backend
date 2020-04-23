using DAL.App.DTO;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class DailyNutritionIntakeMapper : IBaseDALMapper<Domain.DailyNutritionIntake, DailyNutritionIntake>
    {
        public DailyNutritionIntake MapDomainToDAL(Domain.DailyNutritionIntake domainObject) => 
            new DailyNutritionIntake()
            {
                Id = domainObject.Id,
                AppUserId = domainObject.Id,
                Calories = domainObject.Calories,
                Carbohydrates = domainObject.Carbohydrates,
                LoggedAt = domainObject.LoggedAt,
                Fats = domainObject.Fats,
                Protein = domainObject.Protein,
                UnitTypeId = domainObject.UnitTypeId,
                UnitType = _unitTypeMapper.MapDomainToDAL(domainObject.UnitType)
            };

        public Domain.DailyNutritionIntake MapDALToDomain(DailyNutritionIntake dalObject) =>
            new Domain.DailyNutritionIntake()
            {
                Id = dalObject.Id,
                AppUserId = dalObject.Id,
                Calories = dalObject.Calories,
                Carbohydrates = dalObject.Carbohydrates,
                Fats = dalObject.Fats,
                Protein = dalObject.Protein,
                UnitTypeId = dalObject.UnitTypeId,
            };
    }
}