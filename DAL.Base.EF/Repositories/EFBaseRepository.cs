using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Mappers;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using ee.itcollege.raraja.Contracts.Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Repositories
{
    public class EFBaseRepository<TDbContext, TDomainEntity, TDALEntity> :
        EFBaseRepository<Guid, TDbContext, TDomainEntity, TDALEntity>,
        IBaseRepository<TDALEntity>
    
        where TDomainEntity : class, IDomainEntityIdMetadata<Guid>, new()
        where TDALEntity : class, IDALBaseDTO<Guid>, new()
        where TDbContext: DbContext
    {
        public EFBaseRepository(TDbContext dbContext, IDALMapper<TDomainEntity, TDALEntity> mapper) : base(dbContext, mapper)
        {
        }
    }
 
    public class EFBaseRepository<TKey, TDbContext, TDomainEntity, TDALEntity> : IBaseRepository<TKey, TDALEntity>
        where TDALEntity : class, IDALBaseDTO<TKey>, new()
        where TDomainEntity : class, IDomainEntityIdMetadata<TKey>, new()
        where TKey : IEquatable<TKey>
        where TDbContext: DbContext
    {
        protected IDALMapper<TDomainEntity, TDALEntity> Mapper; 
        protected TDbContext RepoDbContext;
        protected DbSet<TDomainEntity> RepoDbSet;
        
        public EFBaseRepository(TDbContext dbContext, IDALMapper<TDomainEntity, TDALEntity> mapper)
        {
            RepoDbContext = dbContext;
            Mapper = mapper;
            RepoDbSet = RepoDbContext.Set<TDomainEntity>();
            if (RepoDbSet == null)
            {
               throw new ArgumentNullException(typeof(TDALEntity).Name + " was not found as DBSet!");
            }
        }
        public virtual async Task<IEnumerable<TDALEntity>> AllAsync() =>
            (await RepoDbSet.AsNoTracking().ToListAsync()).Select(domainEntity => Mapper.MapDomainToDAL(domainEntity));

        public virtual async Task<TDALEntity> FindAsync(TKey id) =>
            Mapper.MapDomainToDAL(
                await RepoDbSet
                    .AsNoTracking()
                    .FirstOrDefaultAsync(entity => entity.Id.Equals(id))
                );
        
        public virtual TDALEntity Add(TDALEntity entity) => 
            Mapper.MapDomainToDAL(RepoDbSet.Add(Mapper.MapDALToDomain(entity)).Entity);
        
        public virtual TDALEntity Update(TDALEntity entity) => 
            Mapper.MapDomainToDAL(RepoDbSet.Update(Mapper.MapDALToDomain(entity)).Entity);

        public virtual TDALEntity Remove(TDALEntity entity) => 
            Mapper.MapDomainToDAL(RepoDbSet.Remove(Mapper.MapDALToDomain(entity)).Entity);
        public virtual async Task<TDALEntity> RemoveAsync(TKey id) => 
            Mapper.MapDomainToDAL(RepoDbSet.Remove(await RepoDbSet.FindAsync(id)).Entity);
    }
}
