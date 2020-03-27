using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TrainingCycleRepository : EFBaseRepository<TrainingCycle, AppDbContext>, ITrainingCycleRepository
    {
        public TrainingCycleRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}