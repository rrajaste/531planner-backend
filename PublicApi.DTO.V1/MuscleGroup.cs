using System.Collections.Generic;

namespace PublicApi.DTO.V1
{
    public class MuscleGroup
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public IEnumerable<Muscle> Muscles { get; set; } = default!;
    }
}