using System;
using Contracts.DAL.App;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO
{
    public class DailyNutritionIntake : DailyNutritionIntake<Guid>, IDALBaseDTO
    {
    }
    
    public class DailyNutritionIntake<TKey> : IDALBaseDTO<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public int Calories { get; set; }
        public int? Protein { get; set; }
        public int? Fats { get; set; }
        public int? Carbohydrates { get; set; }
        public DateTime LoggedAt { get; set; }
        public TKey AppUserId { get; set; }
        public TKey UnitTypeId { get; set; }
        public AppUser<TKey>? AppUser { get; set; }
        public UnitType? UnitType { get; set; }
    }
}