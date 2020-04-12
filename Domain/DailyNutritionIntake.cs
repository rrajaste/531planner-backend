using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class DailyNutritionIntake : DomainEntity
    {
        [Display(Name = nameof(Calories), ResourceType = typeof(Resources.Domain.DailyNutritionIntake))]
        public int Calories { get; set; }
        
        
        [Display(Name = nameof(Protein), ResourceType = typeof(Resources.Domain.DailyNutritionIntake))]
        public int? Protein { get; set; }
        
        
        [Display(Name = nameof(Fats), ResourceType = typeof(Resources.Domain.DailyNutritionIntake))]
        public int? Fats { get; set; }
        

        [Display(Name = nameof(Carbohydrates), ResourceType = typeof(Resources.Domain.DailyNutritionIntake))]
        public int? Carbohydrates { get; set; }
        
        
        public Guid? AppUserId { get; set; }

        public Guid UnitTypeId { get; set; }
        public AppUser? User { get; set; }
        
        
        [Display(Name = nameof(UnitType), ResourceType = typeof(Resources.Domain.DailyNutritionIntake))]
        public UnitType? UnitType { get; set; }
    }
}