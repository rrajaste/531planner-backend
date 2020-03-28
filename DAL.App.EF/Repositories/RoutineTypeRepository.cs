using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class RoutineTypeRepository : EFBaseRepository<RoutineType, AppDbContext>, IRoutineTypeRepository
    {
        public RoutineTypeRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}