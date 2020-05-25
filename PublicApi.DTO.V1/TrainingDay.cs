using System;
using System.Collections.Generic;

namespace PublicApi.DTO.V1
{
    public class TrainingDay
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Exercise> MainLifts { get; set; } = default!;
        public IEnumerable<Exercise> AccessoryLifts { get; set; } = default!;
    }
}