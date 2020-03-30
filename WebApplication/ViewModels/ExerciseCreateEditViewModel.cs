using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.ViewModels
{
    public class ExerciseCreateEditViewModel
    {
        public Exercise Exercise { get; set; }
        public SelectList ExerciseTypeSelectList { get; set; }
    }
}