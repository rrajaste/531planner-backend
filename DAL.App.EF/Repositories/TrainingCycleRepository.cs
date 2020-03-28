using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class TrainingCycleRepository : EFBaseRepository<TrainingCycle, AppDbContext>, ITrainingCycleRepository
    {
        public TrainingCycleRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}