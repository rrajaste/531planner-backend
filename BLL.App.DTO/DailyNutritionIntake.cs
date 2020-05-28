using System;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class DailyNutritionIntake : DailyNutritionIntake<Guid>, IBLLBaseDTO
    {
    }
    
    public class DailyNutritionIntake<TKey> : IBLLBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public int Calories { get; set; }
        public int? Protein { get; set; }
        public int? Fats { get; set; }
        public int? Carbohydrates { get; set; }
        public DateTime LoggedAt { get; set; }
        public TKey AppUserId { get; set; } = default!;
    }
}