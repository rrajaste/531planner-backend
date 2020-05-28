using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.V1
{
    public class BodyMeasurement : BodyMeasurementEdit
    {
        public string LoggedAt { get; set; } = default!;
    }
     
    public class BodyMeasurementCreate
    {
        [Range(1, 1000)]
        public int Weight { get; set; }

        [Range(1, 1000)]
        public int Height { get; set; }

        [Range(1, 1000)]
        public int Chest { get; set; }

        [Range(1, 1000)]
        public int Waist { get; set; }

        [Range(1, 1000)]
        public int Hip { get; set; }

        [Range(1, 1000)]
        public int Arm { get; set; }
        
        [Range(1, 99)]
        
        public int BodyFatPercentage { get; set; }
    }

    public class BodyMeasurementEdit : BodyMeasurementCreate
    {
        public string Id { get; set; } = default!;
    }
}