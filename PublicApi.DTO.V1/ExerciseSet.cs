using System;

namespace PublicApi.DTO.V1
{
    public class ExerciseSet
    {
        public Guid Id { get; set; }
        public int NrOfReps { get; set; }
        public int Weight { get; set; }
        // public string UnitType  { get; set; }
        public SetType SetType  { get; set; }
    }
}