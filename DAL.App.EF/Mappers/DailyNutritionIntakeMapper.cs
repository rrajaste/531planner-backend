using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class DailyNutritionIntakeMapper : EFBaseMapper, IDALMapper<Domain.App.DailyNutritionIntake, DailyNutritionIntake>
    {
        public DailyNutritionIntakeMapper(IAppDALMapperContext context) : base(context)
        {
        }
        
        public DailyNutritionIntake MapDomainToDAL(Domain.App.DailyNutritionIntake domainObject) => 
            new DailyNutritionIntake()
            {
                Id = domainObject.Id,
                AppUserId = domainObject.AppUserId,
                Calories = domainObject.Calories,
                Carbohydrates = domainObject.Carbohydrates,
                LoggedAt = domainObject.LoggedAt,
                Fats = domainObject.Fats,
                Protein = domainObject.Protein,
                UnitTypeId = domainObject.UnitTypeId,
                UnitType = domainObject.UnitType == null 
                    ? null 
                    : DALMapperContext.UnitTypeMapper.MapDomainToDAL(domainObject.UnitType)
            };

        public Domain.App.DailyNutritionIntake MapDALToDomain(DailyNutritionIntake dalObject) =>
            new Domain.App.DailyNutritionIntake()
            {
                Id = dalObject.Id,
                AppUserId = dalObject.AppUserId,
                Calories = dalObject.Calories,
                Carbohydrates = dalObject.Carbohydrates,
                Fats = dalObject.Fats,
                Protein = dalObject.Protein,
                UnitTypeId = dalObject.UnitTypeId,
            };
    }
}