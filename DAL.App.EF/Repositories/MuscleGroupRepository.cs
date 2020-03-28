using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class MuscleGroupRepository : EFBaseRepository<MuscleGroup, AppDbContext>, IMuscleGroupRepository
    {
        public MuscleGroupRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}