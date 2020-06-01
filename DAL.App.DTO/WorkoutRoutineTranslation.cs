using System;

namespace DAL.App.DTO
{
    public class WorkoutRoutineTranslation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CultureCode { get; set; }
    }
}