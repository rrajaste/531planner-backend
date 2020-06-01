using System;
using System.ComponentModel.DataAnnotations;
using Domain.App.Identity;
using ee.itcollege.raraja.Contracts.Domain;
using ee.itcollege.raraja.Domain;

namespace Domain.App
{
    public class BodyMeasurement : BodyMeasurement<Guid>, IDomainEntityIdMetadata
    {
    }

    public class BodyMeasurement<TKey> : DomainEntityIdMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        [Range(1, int.MaxValue)]
        [Display(Name = nameof(Weight), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public float Weight { get; set; }


        [Range(1, int.MaxValue)]
        [Display(Name = nameof(Height), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public float Height { get; set; }


        [Range(1, int.MaxValue)]
        [Display(Name = nameof(Chest), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public float? Chest { get; set; }


        [Range(1, int.MaxValue)]
        [Display(Name = nameof(Waist), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public float? Waist { get; set; }


        [Range(1, int.MaxValue)]
        [Display(Name = nameof(Hip), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public float? Hip { get; set; }


        [Range(1, int.MaxValue)]
        [Display(Name = nameof(Arm), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public float? Arm { get; set; }


        [Range(1, 99, ErrorMessage = "Body fat percentage must be between 1-99%")]
        [Display(Name = nameof(BodyFatPercentage), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public float BodyFatPercentage { get; set; }

        public TKey AppUserId { get; set; } = default!;

        [Display(Name = nameof(LoggedAt), ResourceType = typeof(Resources.Domain.BodyMeasurement))]
        public DateTime LoggedAt => CreatedAt.Date;

        public AppUser? User { get; set; }
    }
}