using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class BodyMeasurement : DomainEntity
    {
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

        public Guid AppUserId { get; set; } = default!;
        public Guid UnitTypeId { get; set; } = default!;
        
        public UnitType? UnitType { get; set; }
        public AppUser? User { get; set; }
    }
}