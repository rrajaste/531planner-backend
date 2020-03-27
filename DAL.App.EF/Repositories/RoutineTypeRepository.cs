using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class RoutineTypeRepository : EFBaseRepository<RoutineType, AppDbContext>, IRoutineTypeRepository
    {
        public RoutineTypeRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}