using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class MuscleRepository : BaseRepository<Muscle>, IMuscleRepository
    {
        public MuscleRepository(DbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}