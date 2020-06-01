using System;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.V1
{
    public class BodyMeasurement : BodyMeasurementEdit
    {
        [DataType(DataType.Date)] public DateTime LoggedAt { get; set; } = default!;
    }

    public class BodyMeasurementCreate
    {
        [Range(1, 1000)] public float Weight { get; set; }

        [Range(1, 1000)] public float Height { get; set; }

        [Range(1, 1000)] public float Chest { get; set; }

        [Range(1, 1000)] public float Waist { get; set; }

        [Range(1, 1000)] public float Hip { get; set; }

        [Range(1, 1000)] public float Arm { get; set; }

        [Range(1, 99)] public float BodyFatPercentage { get; set; }
    }

    public class BodyMeasurementEdit : BodyMeasurementCreate
    {
        public string Id { get; set; } = default!;
    }
}