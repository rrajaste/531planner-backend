using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.Base.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Repositories
{
    public class EFBaseRepository<TDbContext, TDomainEntity, TDALEntity> :
        EFBaseRepository<Guid, TDbContext, TDomainEntity, TDALEntity>,
        IBaseRepository<TDALEntity>
    
        where TDomainEntity : class, IDomainEntityBaseMetadata<Guid>, new()
        where TDALEntity : class, IDALBaseDTO<Guid>, new()
        where TDbContext: DbContext
    {
        public EFBaseRepository(TDbContext dbContext, IBaseDALMapper<TDomainEntity, TDALEntity> mapper) : base(dbContext, mapper)
        {
        }
    }
 
    public class EFBaseRepository<TKey, TDbContext, TDomainEntity, TDALEntity> : IBaseRepository<TKey, TDALEntity>
        where TDALEntity : class, IDALBaseDTO<TKey>, new()
        where TDomainEntity : class, IDomainEntityBaseMetadata<TKey>, new()
        where TKey : IEquatable<TKey>
        where TDbContext: DbContext
    {
        protected IBaseDALMapper<TDomainEntity, TDALEntity> Mapper; 
        protected TDbContext RepoDbContext;
        protected DbSet<TDomainEntity> RepoDbSet;
        
        public EFBaseRepository(TDbContext dbContext, IBaseDALMapper<TDomainEntity, TDALEntity> mapper)
        {
            RepoDbContext = dbContext;
            Mapper = mapper;
            RepoDbSet = RepoDbContext.Set<TDomainEntity>();
            if (RepoDbSet == null)
            {
               throw new ArgumentNullException(typeof(TDALEntity).Name + " was not found as DBSet!");
            }
        }
        
        public virtual IEnumerable<TDALEntity> All() =>
            RepoDbSet.ToList().Select(domainEntity => Mapper.Map(domainEntity));
        
        public virtual async Task<IEnumerable<TDALEntity>> AllAsync() =>
            (await RepoDbSet.ToListAsync()).Select(domainEntity => Mapper.Map(domainEntity));

        public virtual TDALEntity Find(TKey id) 
            => Mapper.Map(RepoDbSet.Find(id));

        public virtual async Task<TDALEntity> FindAsync(TKey id) =>
            Mapper.Map(await RepoDbSet.FindAsync(id));
        
        public virtual TDALEntity Add(TDALEntity entity) => 
            Mapper.Map(RepoDbSet.Add(Mapper.Map<TDALEntity, TDomainEntity>(entity)).Entity);
        
        public virtual TDALEntity Update(TDALEntity entity) => 
            Mapper.Map(RepoDbSet.Update(Mapper.Map<TDALEntity, TDomainEntity>(entity)).Entity);

        public virtual TDALEntity Remove(TDALEntity entity) => 
            Mapper.Map(RepoDbSet.Remove(Mapper.Map<TDALEntity, TDomainEntity>(entity)).Entity);

        public virtual TDALEntity Remove(TKey id) => Remove(Find(id));
    }
    
}
