using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class TrainingDayTypeRepository : EFBaseRepository<AppDbContext, Domain.TrainingDayType, DAL.App.DTO.TrainingDayType>
        , ITrainingDayTypeRepository
    {
        public TrainingDayTypeRepository(AppDbContext repoDbContext) : base(repoDbContext)
        {
        }
    }
}