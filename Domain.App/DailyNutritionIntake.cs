using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.raraja.Contracts.Domain;
using Domain.App.Identity;
using Domain.Base;
using Domain.Identity;

namespace Domain.App
{
    public class DailyNutritionIntake : DailyNutritionIntake<Guid>, IDomainEntityIdMetadata
    {
    }

    public class DailyNutritionIntake<TKey> : DomainEntityIdMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        [Display(Name = nameof(Calories), ResourceType = typeof(Resources.Domain.DailyNutritionIntake))]
        public float Calories { get; set; }
        
        
        [Display(Name = nameof(Protein), ResourceType = typeof(Resources.Domain.DailyNutritionIntake))]
        public float Protein { get; set; }
        
        
        [Display(Name = nameof(Fats), ResourceType = typeof(Resources.Domain.DailyNutritionIntake))]
        public float Fats { get; set; }
        

        [Display(Name = nameof(Carbohydrates), ResourceType = typeof(Resources.Domain.DailyNutritionIntake))]
        public float Carbohydrates { get; set; }

        [Display(Name = nameof(LoggedAt), ResourceType = typeof(Resources.Domain.DailyNutritionIntake))]
        public DateTime LoggedAt => CreatedAt.Date;
        
        public TKey AppUserId { get; set; }

        public AppUser? User { get; set; }
    }
}