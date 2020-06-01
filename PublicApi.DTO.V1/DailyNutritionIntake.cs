using System;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.V1
{
    public class DailyNutritionIntake : DailyNutritionIntakeEdit
    {
        [DataType(DataType.Date)] public DateTime LoggedAt { get; set; } = default!;
    }

    public class DailyNutritionIntakeCreate
    {
        [Range(1, 10000)] public float Calories { get; set; }

        [Range(1, 1000)] public float Protein { get; set; }

        [Range(1, 1000)] public float Fats { get; set; }

        [Range(1, 1000)] public float Carbohydrates { get; set; }
    }

    public class DailyNutritionIntakeEdit : DailyNutritionIntakeCreate
    {
        public string Id { get; set; } = default!;
    }
}