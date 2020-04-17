using System;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class UnitType : UnitType<Guid>, IDomainEntityBaseMetadata
    {
    }

    public class UnitType<TKey> : DomainEntityBaseMetadata<TKey> 
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