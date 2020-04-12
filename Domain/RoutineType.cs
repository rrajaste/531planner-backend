using System;
using System.ComponentModel.DataAnnotations;
using DAL.Base;

namespace Domain
{
    public class RoutineType : DomainEntity
    {
        [MaxLength(255)]
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.Domain.RoutineType))]

        public string Name { get; set; } = default!;
        [MaxLength(255)]
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.RoutineType))]
        public string Description { get; set; } = default!;
    }
}