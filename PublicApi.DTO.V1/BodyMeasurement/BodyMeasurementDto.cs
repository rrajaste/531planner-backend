using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PublicApi.DTO.V1.UnitType;

namespace PublicApi.DTO.V1.BodyMeasurement
{
    public class BodyMeasurementDto
    {
        public string Id { get; set; }

        [Range(1, int.MaxValue)]
        public int Weight { get; set; }

        [Range(1, int.MaxValue)]
        public int Height { get; set; }

        [Range(1, int.MaxValue)]
        public int? Chest { get; set; }

        [Range(1, int.MaxValue)]
        public int? Waist { get; set; }

        [Range(1, int.MaxValue)]
        public int? Hip { get; set; }

        [Range(1, int.MaxValue)]
        public int? Arm { get; set; }

        [DisplayName("Body fat %")][Range(1, 99, ErrorMessage = "Body fat percentage must be between 1-99%")]
        public int? BodyFatPercentage { get; set; }

        public string CreatedAt { get; set; }
        public UnitTypeDto UnitType { get; set; }
    }
}