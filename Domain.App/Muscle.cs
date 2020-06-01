using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.raraja.Contracts.Domain;
using ee.itcollege.raraja.Domain;

namespace Domain.App
{
    public class Muscle : Muscle<Guid>, IDomainEntityIdMetadata
    {
    }

    public class Muscle<TKey> : DomainEntityIdMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        [MaxLength(255)]
        [Display(Name = nameof(Name), ResourceType = typeof(Resources.Domain.Muscle))]
        public string Name { get; set; } = default!;

        [MaxLength(10240)]
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.Muscle))]
        public string Description { get; set; } = default!;

        public TKey MuscleGroupId { get; set; } = default!;

        [Display(Name = nameof(MuscleGroup), ResourceType = typeof(Resources.Domain.Muscle))]
        public MuscleGroup? MuscleGroup { get; set; }
    }
}