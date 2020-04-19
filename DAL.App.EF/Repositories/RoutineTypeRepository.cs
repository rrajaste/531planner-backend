using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class RoutineTypeRepository : EFBaseRepository<AppDbContext, Domain.RoutineType, DAL.App.DTO.RoutineType>,
        IRoutineTypeRepository
    {
        public RoutineTypeRepository(AppDbContext repoDbContext) : base(repoDbContext, new BaseDALMapper<RoutineType, DTO.RoutineType>())
        {
        }
    }
}