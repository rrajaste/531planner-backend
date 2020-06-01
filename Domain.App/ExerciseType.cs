using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.raraja.Contracts.Domain;
using Domain.Base;

namespace Domain.App
{
    public class ExerciseType : ExerciseType<Guid>, IDomainEntityIdMetadata
    {
    }

    public class ExerciseType<TKey> : DomainEntityIdMetadata<TKey> 
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
        
        [Display(Name = nameof(TypeCode), ResourceType = typeof(Resources.Domain.ExerciseType))]
        public string TypeCode { get; set; } = default!;
        public ICollection<Exercise>? Exercises { get; set; }
    }
}