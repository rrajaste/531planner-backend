using System.Collections.Generic;

namespace PublicApi.DTO.V1
{
    public class AccessoryLifts
    {
        public string name { get; set; } = default!;
        public string description { get; set; } = default!;
        public IEnumerable<Exercise> Exercises { get; set; } = default!;
    }
}