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
        public TKey AppUserId { get; set; } = default!;
        public float Weight { get; set; }
        public float Height { get; set; }
        public float? Chest { get; set; }
        public float? Waist { get; set; }
        public float? Hip { get; set; }
        public float? Arm { get; set; }
        public float BodyFatPercentage { get; set; }
        public DateTime LoggedAt { get; set; }
        public TKey Id { get; set; } = default!;
    }
}