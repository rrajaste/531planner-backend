using System;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class BodyMeasurement : BodyMeasurement<Guid>, IDALBaseDTO
    {
    }
    
    public class BodyMeasurement<TKey> : IDALBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public TKey AppUserId { get; set; } = default!;
        public int Weight { get; set; }
        public int Height { get; set; }
        public int? Chest { get; set; }
        public int? Waist { get; set; }
        public int? Hip { get; set; }
        public int? Arm { get; set; }
        public int? BodyFatPercentage { get; set; }
        public DateTime LoggedAt { get; set; } = default!;
    }
}