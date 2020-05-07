using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain;
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
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.Domain.ExerciseType))]
        
        public string Name { get; set; } = default!;
        [MaxLength(255)]
        
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.ExerciseType))]
        public string Description { get; set; } = default!;
        
        [Display(Name = nameof(TypeCode), ResourceType = typeof(Resources.Domain.ExerciseType))]
        public string TypeCode { get; set; } = default!;
        public ICollection<Exercise>? Exercises { get; set; }
    }
}