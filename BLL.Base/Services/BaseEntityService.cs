using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.Base;
using Contracts.BLL.Base.Mappers;
using Contracts.BLL.Base.Services;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;

namespace BLL.Base.Services
{
    public class BaseEntityService<TServiceRepository, TUnitOfWork, TDALEntity, TBLLEntity> : BaseService,  IBaseEntityService<TBLLEntity> 
        where TBLLEntity : class, IBLLBaseDTO, new() 
        where TDALEntity : class, IDALBaseDTO, new()
        where TUnitOfWork : IBaseUnitOfWork
        where TServiceRepository : IBaseRepository<TDALEntity>
    {
        protected readonly TServiceRepository ServiceRepository;
        protected readonly TUnitOfWork UnitOfWork;
        protected readonly IBaseBLLMapper<TDALEntity, TBLLEntity> Mapper;

        public BaseEntityService(TUnitOfWork unitOfWork, IBaseBLLMapper<TDALEntity, TBLLEntity> mapper, TServiceRepository serviceRepository)
        {
            UnitOfWork = unitOfWork;
            ServiceRepository = serviceRepository;
            Mapper = mapper;
        }

        public virtual IEnumerable<TBLLEntity> All() => 
            ServiceRepository.All().Select(e => Mapper.Map<TDALEntity, TBLLEntity>(e));

        public virtual async Task<IEnumerable<TBLLEntity>> AllAsync() => 
            (await ServiceRepository.AllAsync()).Select(e => Mapper.Map<TDALEntity, TBLLEntity>(e));
        

        public virtual TBLLEntity Find(Guid id) => 
            Mapper.Map<TDALEntity, TBLLEntity>(ServiceRepository.Find(id));

        public virtual async Task<TBLLEntity> FindAsync(Guid id) => 
            Mapper.Map<TDALEntity, TBLLEntity>(await ServiceRepository.FindAsync(id));
        

        public virtual TBLLEntity Add(TBLLEntity entity) => 
            Mapper.Map<TDALEntity, TBLLEntity>(
                ServiceRepository.Add( Mapper.Map<TBLLEntity, TDALEntity>(entity)));

        public virtual TBLLEntity Update(TBLLEntity entity) => 
            Mapper.Map<TDALEntity, TBLLEntity>(ServiceRepository.Update( 
                Mapper.Map<TBLLEntity, TDALEntity>(entity)));

        public virtual TBLLEntity Remove(TBLLEntity entity)  => 
            Mapper.Map<TDALEntity, TBLLEntity>(ServiceRepository.Remove(
                Mapper.Map<TBLLEntity, TDALEntity>(entity)));
        
        public virtual TBLLEntity Remove(Guid id) 
            => Mapper.Map<TDALEntity, TBLLEntity>(ServiceRepository.Find(id));
        
    }
}