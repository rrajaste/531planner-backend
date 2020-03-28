using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class MuscleRepository : EFBaseRepository<Muscle, AppDbContext>, IMuscleRepository
    {
        public MuscleRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}