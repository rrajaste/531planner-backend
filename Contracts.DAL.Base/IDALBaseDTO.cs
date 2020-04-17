using System;

namespace Contracts.DAL.Base
{
    
    public interface IDALBaseDTO : IDALBaseDTO<Guid>
    {
    }
    
    public interface IDALBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}