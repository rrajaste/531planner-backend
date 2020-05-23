using System;
using System.Collections.Generic;

namespace PublicApi.DTO.V1
{
    public class TrainingCycle
    {
        public Guid Id { get; set; }
        public int CycleNumber { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public IEnumerable<TrainingWeek> TrainingWeeks { get; set; } = default!;
    }
}