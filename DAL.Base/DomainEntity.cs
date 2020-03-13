using System;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;

namespace DAL.Base
{
    public abstract class DomainEntity : IDomainEntity<string>
    {
        public virtual string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime DeletedAt { get; set; } = DateTime.MaxValue;
        [MaxLength(255)]
        public string? Comment { get; set; }
    }
}