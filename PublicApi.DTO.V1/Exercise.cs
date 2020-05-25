using System;
using System.Collections.Generic;

namespace PublicApi.DTO.V1
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
        public IEnumerable<ExerciseSet> WarmUpSets { get; set; }
        public IEnumerable<ExerciseSet> WorkSets { get; set; }
    }
}