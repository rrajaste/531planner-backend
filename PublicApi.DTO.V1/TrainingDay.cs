using System;
using System.Collections.Generic;

namespace PublicApi.DTO.V1
{
    public class TrainingDay
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public TrainingDayType TrainingDayType { get; set; }
        public IEnumerable<Exercise> MainLifts { get; set; } = default!;
        public IEnumerable<Exercise> AccessoryLifts { get; set; } = default!;
    }
}