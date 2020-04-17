using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class ExerciseType : ExerciseType<Guid>, IDomainEntityBaseMetadata
    {
    }

    public class ExerciseType<TKey> : DomainEntityBaseMetadata<TKey> 
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