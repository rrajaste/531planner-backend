using System;
using Contracts.DAL.App;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class BodyMeasurement : BodyMeasurement<Guid>, IDALBaseDTO
    {
    }
    
    public class BodyMeasurement<TKey> : IDALBaseDTO<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
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