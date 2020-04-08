using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Repositories
{
    public class EFBaseRepository<TEntity, TDbContext> : EFBaseRepository<TEntity, Guid, TDbContext>, IBaseRepository<TEntity>
        where TEntity : class, IDomainEntity<Guid>, new()
        where TDbContext: DbContext
    {
        public EFBaseRepository(TDbContext dbContext) : base(dbContext)
        {
        }
    }

    public class EFBaseRepository<TEntity, TKey, TDbContext> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IDomainEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
        where TDbContext: DbContext
    {
        protected TDbContext RepoDbContext;
        protected DbSet<TEntity> RepoDbSet;
        public EFBaseRepository(TDbContext dbContext)
        {
            RepoDbContext = dbContext;
            RepoDbSet = RepoDbContext.Set<TEntity>();
            if (RepoDbSet == null)
            {
               throw new ArgumentNullException(typeof(TEntity).Name + " was not found as DBSet!");
            }
        }
        
        public virtual IEnumerable<TEntity> All()
        {
            return RepoDbSet.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await RepoDbSet.ToListAsync();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Find(TKey? id)
        {
            return RepoDbSet.Find(id);
        }

        public virtual async Task<TEntity> FindAsync(TKey? id)
        {
            return await RepoDbSet.FindAsync(id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return RepoDbSet.Add(entity).Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            return RepoDbSet.Update(entity).Entity;
        }

        public virtual TEntity Remove(TEntity entity)
        {
            return RepoDbSet.Remove(entity).Entity;
        }

        public virtual TEntity Remove(TKey? id)
        {
            return Remove(Find(id));
        }
        
        

    }
    
}
