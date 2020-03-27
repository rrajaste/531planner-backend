using Contracts.DAL.App;
using Contracts.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class UnitsTypeRepository : EFBaseRepository<UnitsType, AppDbContext>, IUnitsTypeRepository
    {
        public UnitsTypeRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}