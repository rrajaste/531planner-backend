using System;

namespace DAL.App.DTO
{
    public class WorkoutRoutineTranslation
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string CultureCode { get; set; } = default!;
    }
}