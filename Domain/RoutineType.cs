using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class RoutineType : RoutineType<Guid>, IDomainEntityBaseMetadata
    {
    }

    public class RoutineType<TKey> : DomainEntityBaseMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        [MaxLength(255)]
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.Domain.RoutineType))]

        public string Name { get; set; } = default!;
        [MaxLength(255)]
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.RoutineType))]
        public string Description { get; set; } = default!;
        
        public TKey? ParentTypeId { get; set; }
        
        public ICollection<RoutineType>? SubTypes { get; set; }
    }
}