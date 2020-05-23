using System;
using System.Collections.Generic;

namespace PublicApi.DTO.V1.Mappers
{
    public class WorkoutRoutine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TrainingCycle>? TrainingCycles { get; set; }
    }
}