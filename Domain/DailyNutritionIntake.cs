using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class DailyNutritionIntake : DomainEntity
    {
        public int Calories { get; set; }
        public int? Protein { get; set; }
        public int? Fats { get; set; }
        public int? Carbohydrates { get; set; }
        public string AppUserId { get; set; }
        public string UnitsTypeId { get; set; }
        public AppUser? User { get; set; }
        public UnitsType? UnitsType { get; set; }
    }
}