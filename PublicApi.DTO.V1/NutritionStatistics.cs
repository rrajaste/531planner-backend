using System;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.V1
{
    public class NutritionStatistics
    {
        public float TDEE { get; set; }
        public float PredictedProteinNeed { get; set; }
        public float PredictedWeightChange { get; set; }
        public float AverageCalories { get; set; }
        public float AverageProtein { get; set; }
        public float AverageCaloriesTdeeDelta { get; set; }

        [DataType(DataType.Date)] public DateTime FirstLogAt { get; set; }
    }
}