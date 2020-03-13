using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class MuscleGroup : DomainEntity
    {
        [MaxLength(255)]
        public string Name { get; set; } = default!;
        [MaxLength(255)]
        public string Description { get; set; } = default!;
        
        public ICollection<TargetMuscleGroup>? TargetMuscleGroups { get; set; }
        public ICollection<Muscle>? Muscles { get; set; }
    }
}