using System;
using Domain;
using Domain.Identity;

namespace PublicApi.DTO.V1
{
    public class DailyNutritionIntakeDto
    {
        public string Id { get; set; }
        public int Calories { get; set; }
        public int? Protein { get; set; }
        public int? Fats { get; set; }
        public int? Carbohydrates { get; set; }
        public DateTime? CreatedAt { get; set; }
        
        public string UnitTypeId { get; set; }
        public UnitTypeDto? UnitType { get; set; }
    }
}