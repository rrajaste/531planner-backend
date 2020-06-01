using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.V1
{
    public class TrainingWeek
    {
        public Guid Id { get; set; }
        public int WeekNumber { get; set; }
        public bool IsDeload { get; set; }

        [DataType(DataType.Date)] public DateTime StartingDate { get; set; }

        [DataType(DataType.Date)] public DateTime EndingDate { get; set; }

        public IEnumerable<TrainingDay> TrainingDays { get; set; } = default!;
    }
}