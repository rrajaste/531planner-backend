using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class TrainingDayTypeRepository : EFBaseRepository<AppDbContext, TrainingDayType, DAL.App.DTO.TrainingDayType>
        , ITrainingDayTypeRepository
    {
        public TrainingDayTypeRepository(AppDbContext repoDbContext, IDALMapper<TrainingDayType, DAL.App.DTO.TrainingDayType> mapper) 
            : base(repoDbContext, mapper)
        {
            
        }
    }
}