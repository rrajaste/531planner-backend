namespace PublicApi.DTO.V1
{
    public class DailyNutritionIntake : DailyNutritionIntakeEdit
    {
        public string UnitType { get; set; } = default!;
        public string LoggedAt { get; set; } = default!;
    }

    public class DailyNutritionIntakeCreate
    {
        public int Calories { get; set; }
        public int? Protein { get; set; }
        public int? Fats { get; set; }
        public int? Carbohydrates { get; set; }
        public string UnitTypeId { get; set; } = default!;
    }

    public class DailyNutritionIntakeEdit : DailyNutritionIntakeCreate
    {
        public string Id { get; set; } = default!;
    }
}