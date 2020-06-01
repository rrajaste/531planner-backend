using System.Collections.Generic;
using BLL.App.DTO;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class ExerciseInTrainingDayViewModel
    {
        public ICollection<ExerciseSet> WarmupSets { get; set; } = default!;
        public ICollection<ExerciseSet> WorkSets { get; set; } = default!;
    }
}