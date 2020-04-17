using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class Muscle : Muscle<Guid>, IDomainEntityBaseMetadata
    {
    }

    public class Muscle<TKey> : DomainEntityBaseMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        [MaxLength(255)]
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.Domain.Muscle))]
        public string Name { get; set; } = default!;
        [MaxLength(255)]
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.Muscle))]
        public string Description { get; set; } = default!;
        public TKey MuscleGroupId { get; set; } = default!;
        [Display(Name = nameof(MuscleGroup), ResourceType = typeof(Resources.Domain.Muscle))]
        public MuscleGroup? MuscleGroup { get; set; }
    }
}