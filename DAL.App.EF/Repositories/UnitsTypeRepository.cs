using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class UnitTypesRepository : EFBaseRepository<UnitsType, AppDbContext>, IUnitTypesRepository
    {
        public UnitTypesRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}