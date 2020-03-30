using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.ViewModels
{
    public class DailyNutritionIntakeCreateEditViewModel
    {
        public DailyNutritionIntake DailyNutritionIntake { get; set; }
        public SelectList? UnitTypeSelectList { get; set; }
    }
}