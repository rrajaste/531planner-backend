using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class RoutineTypeRepository : BaseRepository<RoutineType>, IRoutineTypeRepository
    {
        public RoutineTypeRepository(DbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}