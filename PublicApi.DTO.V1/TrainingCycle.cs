using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.V1
{
    public class TrainingCycle
    {
        public Guid Id { get; set; }
        public int CycleNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndingDate { get; set; }
        public IEnumerable<TrainingWeek> TrainingWeeks { get; set; } = default!;
    }
}