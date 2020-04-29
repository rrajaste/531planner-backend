using Contracts.DAL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF.Repositories
{
    public class RoutineTypeRepository : EFBaseRepository<AppDbContext, Domain.RoutineType, DTO.RoutineType>,
        IRoutineTypeRepository
    {
        public RoutineTypeRepository(AppDbContext dbContext, IDALMapper<RoutineType, DTO.RoutineType> mapper) 
            : base(dbContext, mapper)
        {
            
        }
    }
}