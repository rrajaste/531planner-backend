using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Contracts.DAL.App.Mappers;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class TrainingWeekRepository : EFBaseRepository<AppDbContext, TrainingWeek, DAL.App.DTO.TrainingWeek>,
        ITrainingWeekRepository
    {
        public TrainingWeekRepository(AppDbContext repoDbContext, IDALMapper<TrainingWeek, DAL.App.DTO.TrainingWeek> mapper) 
            : base(repoDbContext, mapper)
        {
        }
    }
}