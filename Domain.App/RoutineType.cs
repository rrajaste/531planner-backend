using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain;
using Domain.Base;

namespace Domain.App
{
    public class RoutineType : RoutineType<Guid>, IDomainEntityIdMetadata
    {
    }

    public class RoutineType<TKey> : DomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        [MaxLength(255)]
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.Domain.RoutineType))]

        public string Name { get; set; } = default!;
        [MaxLength(10240)]
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.RoutineType))]
        public string Description { get; set; } = default!;
        
        public TKey? ParentTypeId { get; set; }
        
        public ICollection<RoutineType>? SubTypes { get; set; }
    }
}