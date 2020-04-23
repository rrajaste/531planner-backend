using System;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class DailyNutritionIntake : DailyNutritionIntake<Guid>, IDALBaseDTO
    {
    }
    
    public class DailyNutritionIntake<TKey> : IDALBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public int Calories { get; set; }
        public int? Protein { get; set; }
        public int? Fats { get; set; }
        public int? Carbohydrates { get; set; }
        public DateTime LoggedAt { get; set; }
        public TKey AppUserId { get; set; } = default!;
        public TKey UnitTypeId { get; set; } = default!;
        public UnitType? UnitType { get; set; }
    }
}