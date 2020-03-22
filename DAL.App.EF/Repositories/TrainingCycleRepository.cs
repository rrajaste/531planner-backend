using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TrainingCycleRepository : BaseRepository<TrainingCycle>, ITrainingCycleRepository
    {
        public TrainingCycleRepository(DbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}