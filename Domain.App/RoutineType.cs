using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.raraja.Contracts.Domain;
using ee.itcollege.raraja.Domain;

namespace Domain.App
{
    public class RoutineType : RoutineType<Guid>, IDomainEntityIdMetadata
    {
    }

    public class RoutineType<TKey> : DomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        [MaxLength(255)]
        public string Name_eng { get; set; } = default!;
        
        [MaxLength(1024)]
        public string Description_eng { get; set; } = default!;
        
        [MaxLength(255)]
        public string Name_et { get; set; } = default!;
        
        
        [MaxLength(1024)]
        public string Description_et { get; set; } = default!;
        
        public TKey? ParentTypeId { get; set; }
        
        public ICollection<RoutineType>? SubTypes { get; set; }
    }
}