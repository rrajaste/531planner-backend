using System.Collections.Generic;

namespace PublicApi.DTO.V1
{
    public class WorkSets
    {
        public string name { get; set; } = default!;
        public string description { get; set; } = default!;
        public IEnumerable<ExerciseSet> Sets { get; set; } = default!;
    }
}