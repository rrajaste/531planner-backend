using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.raraja.Contracts.Domain;
using ee.itcollege.raraja.Domain;

namespace Domain.App
{
    public class Exercise : Exercise<Guid>, IDomainEntityIdMetadata
    {
    }

    public class Exercise<TKey> : DomainEntityIdMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        [MaxLength(255)] public string NameET { get; set; } = default!;
        [MaxLength(255)] public string NameENG { get; set; } = default!;

        [MaxLength(10240)] public string DescriptionET { get; set; } = default!;

        public string DescriptionENG { get; set; } = default!;
        public ICollection<TargetMuscleGroup>? TargetMuscleGroups { get; set; }
    }
}