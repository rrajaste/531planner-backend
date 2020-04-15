using System;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF
{
    public class EFBaseUnitOfWork<TDbContext> : BaseUnitOfWork
        where TDbContext : DbContext
    {
        protected TDbContext UnitOfWorkDbContext;
        
        public EFBaseUnitOfWork(TDbContext unitOfWorkDbContext)
        {
            UnitOfWorkDbContext = unitOfWorkDbContext;
        }

        public override int SaveChanges()
        {
            return UnitOfWorkDbContext.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            return UnitOfWorkDbContext.SaveChangesAsync();
        }
    }
}