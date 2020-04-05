using System;
using Domain;
using Domain.Identity;

namespace PublicApi.DTO.V1
{
    public class DailyNutritionIntakeDto
    {
        public Guid Id { get; set; }
        public int Calories { get; set; }
        public int? Protein { get; set; }
        public int? Fats { get; set; }
        public int? Carbohydrates { get; set; }
        public UnitTypeDto UnitType { get; set; }
    }
}