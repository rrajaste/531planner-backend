using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using DAL.Base.Mappers;


namespace DAL.App.EF.Repositories
{
    public class TrainingWeekRepository : EFBaseRepository<AppDbContext, Domain.TrainingWeek, DAL.App.DTO.TrainingWeek>,
        ITrainingWeekRepository
    {
        public TrainingWeekRepository(AppDbContext repoDbContext, IDALMapper<Domain.TrainingWeek, DAL.App.DTO.TrainingWeek> mapper) 
            : base(repoDbContext, mapper)
        {
        }
    }
}