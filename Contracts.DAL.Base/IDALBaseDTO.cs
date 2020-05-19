using System;

namespace Contracts.DAL.Base
{
    
    public interface IDALBaseDTO : IDALBaseDTO<Guid>
    {
    }
    
    public interface IDALBaseDTO<TKey> 
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}