using System;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.V1
{
    public class RoutineGenerationInfo
    {
        public Guid BaseRoutineId { get; set; } = default!;
        public DateTime StartingDate { get; set; }
        public bool AddDeloadWeek { get; set; }
        public float SquatMax { get; set; }
        public float DeadliftMax { get; set; }
        public float BenchPressMax { get; set; }
        public float OverHeadPressMax { get; set; }
    }
}