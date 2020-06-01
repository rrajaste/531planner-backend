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
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Fats { get; set; }
        public float Carbohydrates { get; set; }
        public DateTime LoggedAt { get; set; }
        public TKey AppUserId { get; set; } = default!;
        public TKey Id { get; set; } = default!;
    }
}