using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class TrainingCycleRepository :
        EFBaseRepository<AppDbContext, Domain.TrainingCycle, DAL.App.DTO.TrainingCycle>,
        ITrainingCycleRepository
    {
        public TrainingCycleRepository(AppDbContext repoDbContext, IDALMapper<Domain.TrainingCycle, DAL.App.DTO.TrainingCycle> mapper) 
            : base(repoDbContext, mapper)
        {
        }
    }
}