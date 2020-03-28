using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class TrainingWeekRepository : EFBaseRepository<TrainingWeek, AppDbContext>, ITrainingWeekRepository
    {
        public TrainingWeekRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}