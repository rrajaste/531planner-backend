using System;
using Contracts.BLL.Base;

namespace BLL.App.DTO
{
    public class BodyMeasurement : BodyMeasurement<Guid>, IBLLBaseDTO
    {
    }
    
    public class BodyMeasurement<TKey> : IBLLBaseDTO<TKey>
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
        public TKey UnitTypeId { get; set; } = default!;
        public DateTime LoggedAt { get; set; } = default!;
        public UnitType? UnitType { get; set; }
    }
}