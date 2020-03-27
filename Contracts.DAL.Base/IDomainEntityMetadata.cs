using System;

namespace Contracts.DAL.Base
{
    public interface IDomainEntityMetadata
    {
        DateTime CreatedAt { get; set; }
        DateTime ClosedAt { get; set; }
        string? Comment { get; set; }
    }
}