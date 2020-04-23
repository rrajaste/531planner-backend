using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using DAL.Base.Mappers;

namespace DAL.App.EF.Repositories
{
    public class TrainingDayTypeRepository : EFBaseRepository<AppDbContext, Domain.TrainingDayType, DAL.App.DTO.TrainingDayType>
        , ITrainingDayTypeRepository
    {
        public TrainingDayTypeRepository(AppDbContext repoDbContext, IDALMapper<Domain.TrainingDayType, DAL.App.DTO.TrainingDayType> mapper) 
            : base(repoDbContext, mapper)
        {
            
        }
    }
}