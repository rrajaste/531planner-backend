namespace PublicApi.DTO.V1.DailyNutritionIntake
{
    public class DailyNutritionIntakeCreateDto
    {
        public int Calories { get; set; }
        public int? Protein { get; set; }
        public int? Fats { get; set; }
        public int? Carbohydrates { get; set; }
        public string UnitTypeId { get; set; }
    }
}