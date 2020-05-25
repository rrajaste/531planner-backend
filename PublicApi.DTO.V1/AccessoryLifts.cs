using System.Collections.Generic;

namespace PublicApi.DTO.V1
{
    public class AccessoryLifts
    {
        public string name { get; set; }
        public string description { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
    }
}