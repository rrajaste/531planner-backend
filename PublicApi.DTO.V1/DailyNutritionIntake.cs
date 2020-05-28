using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.V1
{
    public class DailyNutritionIntake : DailyNutritionIntakeEdit
    {
        public string LoggedAt { get; set; } = default!;
    }

    public class DailyNutritionIntakeCreate
    {
        [Range(1, 10000)]
        public int Calories { get; set; }
        [Range(1, 1000)]
        public int Protein { get; set; }
        [Range(1, 1000)]
        public int Fats { get; set; }
        
        [Range(1, 1000)]
        public int Carbohydrates { get; set; }
    }

    public class DailyNutritionIntakeEdit : DailyNutritionIntakeCreate
    {
        public string Id { get; set; } = default!;
    }
}