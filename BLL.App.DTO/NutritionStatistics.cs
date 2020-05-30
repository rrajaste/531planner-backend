using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class NutritionStatistics
    {
        [DataType(DataType.Date)]
        public DateTime FirstLogAt { get; set; }
        public float TDEE { get; set; }
        public float PredictedProteinNeed { get; set; }
        public float PredictedWeightChange { get; set; }
        public float AverageCalories { get; set; }
        public float AverageProtein { get; set; }
        public float AverageCaloriesTdeeDelta { get; set; }
    }
}