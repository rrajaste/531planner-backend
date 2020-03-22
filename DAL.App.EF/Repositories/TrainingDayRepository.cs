using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TrainingDayRepository : BaseRepository<TrainingDay>, ITrainingDayRepository
    {
        public TrainingDayRepository(DbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}