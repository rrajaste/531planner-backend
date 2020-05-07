using System;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain;
using Domain.Base;

namespace Domain.App
{
    public class SetType : SetType<Guid>, IDomainEntityIdMetadata
    {
    }
    // TODO: Fix display names
    public class SetType<TKey> : DomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        [MaxLength(255)]
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.Domain.UnitType))]
        public string Name { get; set; } = default!;
        
        
        [MaxLength(255)]
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.UnitType))]
        public string Description { get; set; } = default!;
    }
}