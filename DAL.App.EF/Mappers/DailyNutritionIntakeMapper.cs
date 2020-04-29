using Contracts.DAL.App;
using Contracts.DAL.App.Mappers;
using DAL.App.DTO;
using DAL.Base.EF;

namespace DAL.App.EF.Mappers
{
    public class DailyNutritionIntakeMapper : EFBaseMapper, IDALMapper<Domain.DailyNutritionIntake, DailyNutritionIntake>
    {
        public DailyNutritionIntakeMapper(IAppMapperContext context) : base(context)
        {
        }
        
        public DailyNutritionIntake MapDomainToDAL(Domain.DailyNutritionIntake domainObject) => 
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
                    : MapperContext.UnitTypeMapper.MapDomainToDAL(domainObject.UnitType)
            };

        public Domain.DailyNutritionIntake MapDALToDomain(DailyNutritionIntake dalObject) =>
            new Domain.DailyNutritionIntake()
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