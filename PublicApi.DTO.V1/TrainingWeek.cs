using System;
using System.Collections.Generic;

namespace PublicApi.DTO.V1
{
    public class TrainingWeek
    {
        public Guid Id { get; set; }
        public int WeekNumber { get; set; }
        public bool IsDeload { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public IEnumerable<TrainingDay> TrainingDays { get; set; } = default!;
    }
}
