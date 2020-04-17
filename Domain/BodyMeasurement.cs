using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;
using Domain.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain
{
    public class BodyMeasurement : BodyMeasurement<Guid>, IDomainEntityBaseMetadata
    {
    }
    
    public class BodyMeasurement<TKey> : DomainEntityBaseMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        
        [Range(1, int.MaxValue)]
        [Display(Name = nameof(Weight), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public int Weight { get; set; }
        
        
        [Range(1, int.MaxValue)]
        [Display(Name = nameof(Height), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public int Height { get; set; }
        
        
        [Range(1, int.MaxValue)]
        [Display(Name = nameof(Chest), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public int? Chest { get; set; }
        
        
        [Range(1, int.MaxValue)]
        [Display(Name = nameof(Waist), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public int? Waist { get; set; }
        
        
        [Range(1, int.MaxValue)]
        [Display(Name = nameof(Hip), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public int? Hip { get; set; }
        
        
        [Range(1, int.MaxValue)]
        [Display(Name = nameof(Arm), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public int? Arm { get; set; }
        
        
        [Range(1, 99, ErrorMessage = "Body fat percentage must be between 1-99%")]
        [Display(Name = nameof(BodyFatPercentage), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public int? BodyFatPercentage { get; set; }

        public TKey AppUserId { get; set; } = default!;
        public TKey UnitTypeId { get; set; } = default!;
    
        [Display(Name = nameof(LoggedAt), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public DateTime LoggedAt => CreatedAt.Date;
        
        [Display(Name = nameof(UnitType), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public UnitType? UnitType { get; set; }
        public AppUser? User { get; set; }
    }
}