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
        public int Calories { get; set; }
        public int? Protein { get; set; }
        public int? Fats { get; set; }
        public int? Carbohydrates { get; set; }
        public Guid? AppUserId { get; set; }
        public Guid UnitTypeId { get; set; }
        public AppUser? User { get; set; }
        public UnitType? UnitType { get; set; }
    }
}