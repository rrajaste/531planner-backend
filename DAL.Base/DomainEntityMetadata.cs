using System;
using Contracts.DAL.Base;

namespace DAL.Base
{
    public class DomainEntityMetadata : IDomainEntityMetadata
    {
        public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual DateTime DeletedAt { get; set; } = DateTime.MaxValue;
        public virtual string? Comment { get; set; }
    }
}