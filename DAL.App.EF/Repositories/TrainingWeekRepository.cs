using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TrainingWeekRepository : EFBaseRepository<TrainingWeek,AppDbContext>, ITrainingWeekRepository
    {
        public TrainingWeekRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}