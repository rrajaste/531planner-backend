using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class Muscle : DomainEntity
    {
        [MaxLength(255)]
        public string Name { get; set; } = default!;
        [MaxLength(255)]
        public string Description { get; set; } = default!;
        public Guid MuscleGroupId { get; set; } = default!;
        public MuscleGroup? MuscleGroup { get; set; }
    }
}