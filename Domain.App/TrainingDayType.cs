using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.raraja.Contracts.Domain;
using ee.itcollege.raraja.Domain;

namespace Domain.App
{
    public class TrainingDayType : TrainingDayType<Guid>, IDomainEntityIdMetadata
    {
    }

    public class TrainingDayType<TKey> : DomainEntityIdMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        [MaxLength(255)] public string Name_eng { get; set; } = default!;

        [MaxLength(1024)] public string Description_eng { get; set; } = default!;

        [MaxLength(255)] public string Name_et { get; set; } = default!;


        [MaxLength(1024)] public string Description_et { get; set; } = default!;
    }
}