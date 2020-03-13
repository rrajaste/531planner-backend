using System;

namespace Contracts.DAL.Base
{
    public interface IDomainEntity<TKey> where TKey : IComparable
    {
        TKey Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime DeletedAt { get; set; }
        string? Comment { get; set; }
    }
}