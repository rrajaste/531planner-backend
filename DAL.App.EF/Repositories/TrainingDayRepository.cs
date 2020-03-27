using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TrainingDayRepository : EFBaseRepository<TrainingDay, AppDbContext>, ITrainingDayRepository
    {
        public TrainingDayRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}