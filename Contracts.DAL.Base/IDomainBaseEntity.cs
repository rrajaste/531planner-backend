using System;

namespace Contracts.DAL.Base
{
    public interface IDomainBaseEntity : IDomainBaseEntity<Guid>{
    }
    
    public interface IDomainBaseEntity<TKey> 
        where TKey : IComparable
    {
        public TKey Id { get; set; }
    }
}