using System;
using System.Globalization;

namespace PublicApi.DTO.V1.Mappers
{
    public static class DailyNutritionIntakeMapper
    {
        public static DailyNutritionIntake MapBLLEntityToPublicDTO(BLL.App.DTO.DailyNutritionIntake bllEntity)
        {
            return new DailyNutritionIntake()
            {
                Id = bllEntity.Id.ToString(),
                Calories = bllEntity.Calories,
                Carbohydrates = bllEntity.Carbohydrates,
                Fats = bllEntity.Fats,
                Protein = bllEntity.Protein,
                LoggedAt = bllEntity.LoggedAt.ToString(CultureInfo.CurrentCulture),
                UnitType = bllEntity.UnitType == null ? null : bllEntity.UnitType.Name,
                UnitTypeId = bllEntity.UnitTypeId.ToString()
            };
        }

        public static BLL.App.DTO.DailyNutritionIntake MapPublicDTOToBLLEntity<TDto>(TDto dto)
            where TDto : DailyNutritionIntakeCreate => 
            MapPublicDTOFieldsToBLLEntity(dto, new BLL.App.DTO.DailyNutritionIntake());

        public static BLL.App.DTO.DailyNutritionIntake MapPublicDTOFieldsToBLLEntity<TDto>(TDto dto, BLL.App.DTO.DailyNutritionIntake bllEntity)
            where TDto : DailyNutritionIntakeCreate
        {
            bllEntity.Calories = dto.Calories;
            bllEntity.Carbohydrates = dto.Carbohydrates;
            bllEntity.Fats = dto.Fats;
            bllEntity.Protein = dto.Protein;
            bllEntity.UnitTypeId = Guid.Parse(dto.UnitTypeId);
            return bllEntity;
        }
    }
}