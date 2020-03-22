using Contracts.DAL.App;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TrainingDayTypeRepository : BaseRepository<TrainingDayType>, ITrainingDayTypeRepository
    {
        public TrainingDayTypeRepository(DbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}