using System.Collections.Generic;

namespace PublicApi.DTO.V1
{
    public class WarmUpSets
    {
        public string name { get; set; }
        public string description { get; set; }
        public IEnumerable<ExerciseSet> Sets { get; set; }
    }
}
