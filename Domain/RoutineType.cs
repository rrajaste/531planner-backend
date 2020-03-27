using System;
using System.ComponentModel.DataAnnotations;
using DAL.Base;

namespace Domain
{
    public class RoutineType : DomainEntity
    {
        [MaxLength(255)]
        public string Name { get; set; } = default!;
        [MaxLength(255)]
        public string Description { get; set; } = default!;
    }
}