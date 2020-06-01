using System;
using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class ExerciseSetCreateEditViewModel
    {
        public BaseLiftSet ExerciseSet { get; set; } = default!;
        public SelectList? SetTypes { get; set; } 
        public SelectList? Exercises { get; set; }
        public Guid TrainingDayId { get; set; }
    }
}