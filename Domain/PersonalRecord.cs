using System;
using Contracts.DAL.Base;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class PersonalRecord : PersonalRecord<Guid>, IDomainEntityBaseMetadata
    {
    }

    public class PersonalRecord<TKey> : DomainEntityBaseMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey AppUserId { get; set; }
        public TKey ExerciseSetId { get; set; }
        public AppUser? User { get; set; }
        public ExerciseSet? ExerciseSet { get; set; }
    }
}