using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class TrainingDayType : TrainingDayType<Guid>, IDomainEntityBaseMetadata
    {
    }

    public class TrainingDayType<TKey> : DomainEntityBaseMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        [MaxLength(255)]
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.Domain.TrainingDayType))]
        public string Name { get; set; } = default!;
        
        [MaxLength(255)]
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.TrainingDayType))]
        public string Description { get; set; } = default!;
        public ICollection<TrainingDay>? TrainingDays { get; set; }
    }
}