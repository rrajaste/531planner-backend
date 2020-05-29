using System;

namespace PublicApi.DTO.V1
{
    public class BodyMeasurementStatistics
    {
        public DateTime FirstLogAt { get; set; }
        public float WeightChange { get; set; }
        public float CurrentWeight { get; set; }
        public float CurrentBMI { get; set; }
        public float BMIChange { get; set; }
        public float BodyFatPercentageChange { get; set; }
        public float CurrentBodyFatPercentage { get; set; }
    }
}