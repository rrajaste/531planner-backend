using PublicApi.DTO.V1.UnitType;

namespace PublicApi.DTO.V1.DailyNutritionIntake
{
    public class DailyNutritionIntakeDto
    {
        public string Id { get; set; }
        public int Calories { get; set; }
        public int? Protein { get; set; }
        public int? Fats { get; set; }
        public int? Carbohydrates { get; set; }
        public string CreatedAt { get; set; } 
        public UnitTypeDto UnitType { get; set; }
    }
}