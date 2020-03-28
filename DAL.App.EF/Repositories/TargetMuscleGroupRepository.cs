using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class TargetMuscleGroupRepository : EFBaseRepository<TargetMuscleGroup, AppDbContext>,
        ITargetMuscleGroupRepository
    {
        public TargetMuscleGroupRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}