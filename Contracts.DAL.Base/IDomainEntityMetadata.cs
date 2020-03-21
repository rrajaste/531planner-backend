using System;

namespace Contracts.DAL.Base
{
    public interface IDomainEntityMetadata
    {
        DateTime CreatedAt { get; set; }
        DateTime DeletedAt { get; set; }
        string? Comment { get; set; }
    }
}