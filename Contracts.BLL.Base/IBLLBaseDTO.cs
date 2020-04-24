using System;
using Contracts.DAL.Base;

namespace Contracts.BLL.Base
{
    
    public interface IBLLBaseDTO : IBLLBaseDTO<Guid>
    {
    }
    
    public interface IBLLBaseDTO<TKey> : IDALBaseDTO<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}