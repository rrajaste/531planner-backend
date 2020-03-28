using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class TrainingDayRepository : EFBaseRepository<TrainingDay, AppDbContext>, ITrainingDayRepository
    {
        public TrainingDayRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}