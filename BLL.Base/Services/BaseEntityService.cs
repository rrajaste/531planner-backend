using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.Base.Mappers;
using Contracts.BLL.Base.Services;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;

namespace BLL.Base.Services
{
    public class BaseEntityService<TServiceRepository, TUnitOfWork, TDALEntity, TBLLEntity> : BaseService,  IBaseEntityService<TBLLEntity> 
        where TBLLEntity : class, IDomainEntity<Guid>, new() 
        where TDALEntity : class, IDomainEntity<Guid>, new()
        where TUnitOfWork : IBaseUnitOfWork
        where TServiceRepository : IBaseRepository<TDALEntity>
    {
        protected readonly TServiceRepository ServiceRepository;
        protected readonly TUnitOfWork UnitOfWork;
        private readonly IBaseBLLMapper<TDALEntity, TBLLEntity> _mapper;

        public BaseEntityService(TUnitOfWork unitOfWork, IBaseBLLMapper<TDALEntity, TBLLEntity> mapper, TServiceRepository serviceRepository)
        {
            UnitOfWork = unitOfWork;
            ServiceRepository = serviceRepository;
            _mapper = mapper;
        }

        public virtual IEnumerable<TBLLEntity> All() => 
            ServiceRepository.All().Select(e => _mapper.Map<TBLLEntity, TDALEntity>(e));

        public virtual async Task<IEnumerable<TBLLEntity>> AllAsync() => 
            (await ServiceRepository.AllAsync()).Select(e => _mapper.Map<TBLLEntity, TDALEntity>(e));
        
        public virtual TBLLEntity Find(Guid? id) => 
            _mapper.Map<TBLLEntity, TDALEntity>(ServiceRepository.Find(id));

        public virtual async Task<TBLLEntity> FindAsync(Guid? id) => 
            _mapper.Map<TBLLEntity, TDALEntity>(await ServiceRepository.FindAsync(id));
        

        public virtual TBLLEntity Add(TBLLEntity entity) => 
            _mapper.Map<TBLLEntity, TDALEntity>(
                ServiceRepository.Add( _mapper.Map<TDALEntity, TBLLEntity>(entity)));

        public virtual TBLLEntity Update(TBLLEntity entity) => 
            _mapper.Map<TBLLEntity, TDALEntity>(ServiceRepository.Update( 
                _mapper.Map<TDALEntity, TBLLEntity>(entity)));

        public virtual TBLLEntity Remove(TBLLEntity entity)  => 
            _mapper.Map<TBLLEntity, TDALEntity>(ServiceRepository.Remove( 
                _mapper.Map<TDALEntity, TBLLEntity>(entity)));
       
        public virtual TBLLEntity Remove(Guid? id) 
            => _mapper.Map<TBLLEntity, TDALEntity>(ServiceRepository.Find(id));
        
    }
}