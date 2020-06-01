using System.Threading.Tasks;
using ee.itcollege.raraja.DAL;
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

        public override Task<int> SaveChangesAsync()
        {
            return UnitOfWorkDbContext.SaveChangesAsync();
        }
    }
}