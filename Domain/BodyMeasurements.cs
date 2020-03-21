using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class BodyMeasurements : DomainEntity
    {
        public int Weight { get; set; }
        public int Height { get; set; }
        public int? Chest { get; set; }
        public int? Waist { get; set; }
        public int? Hip { get; set; }
        public int? Arm { get; set; }
        [DisplayName("Body fat %")][Range(1, 99, ErrorMessage = "Body fat percentage must be between 1-99%")]
        public int? BodyFatPercentage { get; set; }
        public string AppUserId { get; set; }
        public string UnitsTypeId { get; set; }
        
        public UnitsType? UnitsType { get; set; }
        public AppUser? User { get; set; }
    }
}