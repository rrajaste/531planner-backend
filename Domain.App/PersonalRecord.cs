using System;
using Contracts.Domain;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App
{
    public class PersonalRecord : PersonalRecord<Guid>, IDomainEntityIdMetadata
    {
    }

    public class PersonalRecord<TKey> : DomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey AppUserId { get; set; }
        public TKey ExerciseSetId { get; set; }
        public AppUser? User { get; set; }
        public ExerciseSet? ExerciseSet { get; set; }
    }
}