using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.Base;
using Contracts.BLL.Base.Services;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;

namespace BLL.Base.Services
{
    public class BaseEntityService<TServiceRepository, TUnitOfWork, TDALEntity, TBLLEntity, TMapper> : BaseService,
        IBaseEntityService<TBLLEntity>
        where TBLLEntity : class, IBLLBaseDTO, new()
        where TMapper : IBLLMapper<TDALEntity, TBLLEntity>
        where TDALEntity : class, IDALBaseDTO, new()
        where TUnitOfWork : IBaseUnitOfWork
        where TServiceRepository : IBaseRepository<TDALEntity>
    {
        protected TMapper Mapper;
        protected TServiceRepository ServiceRepository;
        protected TUnitOfWork UnitOfWork;

        public BaseEntityService(TUnitOfWork unitOfWork, TMapper mapper, TServiceRepository serviceRepository)
        {
            UnitOfWork = unitOfWork;
            ServiceRepository = serviceRepository;
            Mapper = mapper;
        }

        public virtual async Task<IEnumerable<TBLLEntity>> AllAsync()
        {
            return (await ServiceRepository.AllAsync()).Select(e => Mapper.MapDALToBLL(e));
        }

        public virtual async Task<TBLLEntity> FindAsync(Guid id)
        {
            return Mapper.MapDALToBLL(await ServiceRepository.FindAsync(id));
        }


        public virtual TBLLEntity Add(TBLLEntity entity)
        {
            return Mapper.MapDALToBLL(
                ServiceRepository.Add(Mapper.MapBLLToDAL(entity)));
        }

        public virtual TBLLEntity Update(TBLLEntity entity)
        {
            return Mapper.MapDALToBLL(ServiceRepository.Update(
                Mapper.MapBLLToDAL(entity)));
        }

        public virtual TBLLEntity Remove(TBLLEntity entity)
        {
            return Mapper.MapDALToBLL(ServiceRepository.Remove(
                Mapper.MapBLLToDAL(entity)));
        }

        public virtual async Task<TBLLEntity> RemoveAsync(Guid id)
        {
            return Mapper.MapDALToBLL(await ServiceRepository.RemoveAsync(id));
        }
    }
}