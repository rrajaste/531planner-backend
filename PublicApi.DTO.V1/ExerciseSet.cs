using System;

namespace PublicApi.DTO.V1
{
    public class ExerciseSet
    {
        public Guid Id { get; set; }
        public int NrOfReps { get; set; }
        public float? Weight { get; set; }
        public string UnitType  { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
    }
}