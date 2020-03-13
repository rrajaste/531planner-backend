
using System;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class RoutineType : DomainEntity
    {
        public int RoutineTypeId { get; set; }
        [MaxLength(255)]
        public string Name { get; set; } = default!;
        [MaxLength(255)]
        public string Description { get; set; } = default!;
        public DateTime ClosedAt { get; set; }
    }
}