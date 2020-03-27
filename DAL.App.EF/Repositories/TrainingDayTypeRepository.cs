using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TrainingDayTypeRepository : EFBaseRepository<TrainingDayType, AppDbContext>, ITrainingDayTypeRepository
    {
        public TrainingDayTypeRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}