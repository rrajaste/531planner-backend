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
                Fats =  bllEntity.Fats,
                Protein = bllEntity.Protein,
                LoggedAt = bllEntity.LoggedAt,
            };
        }
        
        public static NutritionStatistics MapBLLEntityToPublicDTO(BLL.App.DTO.NutritionStatistics bllEntity)
        {
            return new NutritionStatistics()
            {
                FirstLogAt = bllEntity.FirstLogAt,
                AverageCalories = (float) Math.Round(bllEntity.AverageCalories),
                AverageProtein = (float) Math.Round(bllEntity.AverageProtein, 2),
                TDEE = (float) Math.Round(bllEntity.TDEE),
                PredictedProteinNeed = (float) Math.Round(bllEntity.PredictedProteinNeed, 1),
                PredictedWeightChange = (float) Math.Round(bllEntity.PredictedWeightChange, 3),
                AverageCaloriesTdeeDelta = (float) Math.Round(bllEntity.AverageCaloriesTdeeDelta),
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
            return bllEntity;
        }
    }
}