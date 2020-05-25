using System.Collections.Generic;

namespace PublicApi.DTO.V1
{
    public class WorkSets
    {
        public string name { get; set; }
        public string description { get; set; }
        public IEnumerable<ExerciseSet> Sets { get; set; }
    }
}