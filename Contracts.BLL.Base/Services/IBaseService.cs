using System;
using Contracts.DAL.Base.Repositories;

namespace Contracts.BLL.Base.Services
{
    public interface IBaseService
    {
    }
    public interface IBaseEntityService<TBLLEntity> : IBaseService, IBaseRepository<TBLLEntity> 
        where TBLLEntity : class, IBLLBaseDTO<Guid>, new()
    {
    }
}