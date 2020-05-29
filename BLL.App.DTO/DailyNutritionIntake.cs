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
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Fats { get; set; }
        public float Carbohydrates { get; set; }
        public DateTime LoggedAt { get; set; }
        public TKey AppUserId { get; set; } = default!;
    }
}