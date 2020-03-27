using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class MuscleRepository : EFBaseRepository<Muscle, AppDbContext>, IMuscleRepository
    {
        public MuscleRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}