using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF
{
    public class EFBaseUnitOfWork<TDbContext> : BaseUnitOfWork, IBaseUnitOfWork
        where TDbContext : DbContext
    {
        protected TDbContext UnitOfWorkDbContext;
        
        public EFBaseUnitOfWork(TDbContext unitOfWorkDbContext)
        {
            UnitOfWorkDbContext = unitOfWorkDbContext;
        }

        public int SaveChanges()
        {
            return UnitOfWorkDbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return UnitOfWorkDbContext.SaveChangesAsync();
        }
    }
}