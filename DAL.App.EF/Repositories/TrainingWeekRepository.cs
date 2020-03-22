using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TrainingWeekRepository : BaseRepository<TrainingDay>, ITrainingDayRepository
    {
        public TrainingWeekRepository(DbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}