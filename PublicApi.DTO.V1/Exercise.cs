using System;
using System.Collections.Generic;

namespace PublicApi.DTO.V1
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string TypeName { get; set; } = default!;
        public string TypeDescription { get; set; } = default!;
        public IEnumerable<ExerciseSet> WarmUpSets { get; set; } = default!;
        public IEnumerable<ExerciseSet> WorkSets { get; set; } = default!;
    }
}