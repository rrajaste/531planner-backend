using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.raraja.Contracts.Domain;
using ee.itcollege.raraja.Domain;

namespace Domain.App
{
    public class UnitType : UnitType<Guid>, IDomainEntityIdMetadata
    {
    }

    public class UnitType<TKey> : DomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        [MaxLength(255)]
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.Domain.UnitType))]
        public string Name { get; set; } = default!;
        
        [MaxLength(10240)]
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.UnitType))]
        public string Description { get; set; } = default!;
    }
}