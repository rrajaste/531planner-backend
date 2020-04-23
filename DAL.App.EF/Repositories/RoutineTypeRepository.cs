using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using DAL.Base.Mappers;

namespace DAL.App.EF.Repositories
{
    public class RoutineTypeRepository : EFBaseRepository<AppDbContext, Domain.RoutineType, DAL.App.DTO.RoutineType>,
        IRoutineTypeRepository
    {
        public RoutineTypeRepository(AppDbContext repoDbContext, IDALMapper<Domain.RoutineType, DAL.App.DTO.RoutineType> mapper) 
            : base(repoDbContext, mapper)
        {
        }
    }
}